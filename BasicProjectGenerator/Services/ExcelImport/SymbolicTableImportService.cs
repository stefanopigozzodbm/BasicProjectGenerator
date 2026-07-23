using Basic_Project_Generator.Interfaces;
using Basic_Project_Generator.Models;
using NPOI.SS.UserModel;
using Siemens.Engineering.HW;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Basic_Project_Generator.Services
{
    public class SymbolicTableImportService
    {
        private const int ColumnSiglaScheda = 3;  // colonna D
        private const int ColumnCodiceUnita = 6;  // colonna G
        private const int ColumnTipologia = 7;    // colonna H
        private const int ColumnIndirizzo = 8;    // colonna I
        private const int ColumnPotentialGroup = 9;  // colonna J
        private const int ColumnDescrizione1 = 11; // colonna L
        private const int ColumnPin1 = 15;         // colonna P
        private const int ColumnPin2 = 16;         // colonna Q

        private static readonly string[] ReserveKeywords = { "RISERVA", "RESERVE" };// valori di Stringa sulla colonna Descrizione1 che indicano che la riga non deve essere considerata per i canali Safety

        private enum Direction { Input, Output }

        private readonly TraceWriter _traceWriter;

        public SymbolicTableImportService(TraceWriter traceWriter)
        {
            _traceWriter = traceWriter;
        }

        public List<ImportedSymbolItem> Import(string filePath, Catalog deviceCatalog, ModuleCatalog moduleCatalog)
        {
            var result = new List<ImportedSymbolItem>();
            ImportedSymbolItem currentItem = null;
            var currentSafetyRows = new List<(string Description, string Pin1Raw, string Pin2Raw, string Indirizzo)>();

            using (var stream = File.OpenRead(filePath))
            {
                var workbook = WorkbookFactory.Create(stream);
                var sheet = workbook.GetSheetAt(0);

                for (var r = 1; r <= sheet.LastRowNum; r++)
                {
                    var row = sheet.GetRow(r);
                    if (row == null) continue;

                    var orderNumber = GetCellText(row, ColumnCodiceUnita);

                    if (!string.IsNullOrWhiteSpace(orderNumber))
                    {
                        // Prima di passare alla scheda successiva, finalizzo i canali Safety di quella precedente
                        FinalizeSafetyChannels(currentItem, currentSafetyRows);
                        currentSafetyRows = new List<(string, string, string, string)>();

                        currentItem = new ImportedSymbolItem
                        {
                            Name = GetCellText(row, ColumnSiglaScheda),
                            OrderNumber = orderNumber,
                            ItemType = SymbolItemType.Unknown,
                            NewPotentialGroup = GetCellText(row, ColumnPotentialGroup).Trim() == "1"
                        };

                        var normalized = Normalize(orderNumber);

                        var deviceMatch = deviceCatalog?.DeviceItemComposition?
                            .FirstOrDefault(d => Normalize(d.OrderNumber) == normalized);

                        if (deviceMatch != null)
                        {
                            currentItem.ItemType = SymbolItemType.Device;
                            currentItem.TypeIdentifier = deviceMatch.TypeIdentifier;
                            currentItem.MatchedDevice = deviceMatch;
                        }
                        else
                        {
                            var moduleMatch = moduleCatalog?.ModuleItemComposition?
                                .FirstOrDefault(m => Normalize(m.OrderNumber) == normalized);

                            if (moduleMatch != null)
                            {
                                currentItem.ItemType = SymbolItemType.Module;
                                currentItem.TypeIdentifier = moduleMatch.TypeIdentifier;
                                currentItem.IsSafetyModule = moduleMatch.IsSafety;
                            }
                        }

                        result.Add(currentItem);
                        continue;
                    }

                    if (currentItem == null) continue;

                    var tipologia = GetCellText(row, ColumnTipologia);
                    var indirizzo = GetCellText(row, ColumnIndirizzo);

                    if (string.IsNullOrWhiteSpace(tipologia) || string.IsNullOrWhiteSpace(indirizzo)) continue;

                    if (TryGetCategory(tipologia, out var category) && TryGetStartAddress(indirizzo, out var startAddress))
                    {
                        switch (category)
                        {
                            case AddressCategory.DigitalInput:
                                if (currentItem.DigitalInputStartAddress == null) currentItem.DigitalInputStartAddress = startAddress;
                                break;
                            case AddressCategory.DigitalOutput:
                                if (currentItem.DigitalOutputStartAddress == null) currentItem.DigitalOutputStartAddress = startAddress;
                                break;
                            case AddressCategory.AnalogInput:
                                if (currentItem.AnalogInputStartAddress == null) currentItem.AnalogInputStartAddress = startAddress;
                                break;
                            case AddressCategory.AnalogOutput:
                                if (currentItem.AnalogOutputStartAddress == null) currentItem.AnalogOutputStartAddress = startAddress;
                                break;
                        }
                    }

                    // Solo per moduli Safety di ingressi: accumulo Descrizione1/Pin1/Pin2 delle righe "I"
                    if (currentItem.IsSafetyModule && (category == AddressCategory.DigitalInput || category == AddressCategory.DigitalOutput))
                    {
                        var description = GetCellText(row, ColumnDescrizione1);
                        var pin1Raw = GetCellText(row, ColumnPin1);
                        var pin2Raw = GetCellText(row, ColumnPin2);

                        if (!string.IsNullOrWhiteSpace(description))
                        {
                            currentSafetyRows.Add((description, pin1Raw, pin2Raw, indirizzo));
                        }
                    }
                }
            }

            FinalizeSafetyChannels(currentItem, currentSafetyRows); // finalizza l'ultima scheda del file

            return result;
        }

        /// <summary>
        /// Raggruppa le righe Safety accumulate per un modulo (per Descrizione1) e ne deriva i canali:
        /// - 2 occorrenze dello stesso simbolo -> 1oo2 equivalent (Evaluation=1), un canale per occorrenza (Pin1-1)
        /// - 1 sola occorrenza -> canale singolo (Evaluation=0)
        /// - Per ogni occorrenza, Failsafe_SensorSupply = numero del canale se Pin2 è popolato in quella riga, altrimenti 8 (esterno)
        /// </summary>
        /// <summary>
        /// Raggruppa le righe Safety accumulate per un modulo (per Descrizione1) e ne deriva i canali:
        /// - 2 occorrenze dello stesso simbolo -> 1oo2 equivalent (Evaluation=1), un canale per occorrenza (Pin1-1)
        /// - 1 sola occorrenza -> canale singolo (Evaluation=0)
        /// - Per ogni occorrenza, Failsafe_SensorSupply = numero del canale se Pin2 è popolato in quella riga, altrimenti 8 (esterno)
        /// </summary>
        private void FinalizeSafetyChannels(ImportedSymbolItem item, List<(string Description, string Pin1Raw, string Pin2Raw, string Indirizzo)> rows)
        {
            if (item == null || !item.IsSafetyModule || rows.Count == 0)
            {
                return;
            }

            var reserveRows = rows
                .Where(r => ReserveKeywords.Any(keyword => string.Equals(r.Description?.Trim(), keyword, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            var reserveChannelNumbers = new List<int>();
            foreach (var reserveRow in reserveRows)
            {
                if (TryGetChannelFromAddress(reserveRow.Indirizzo, out var reserveChannel))
                // fatto cosi se non c'è numero su pin 1... guarda indirizzo !!!! nel caso di 16 ingressi safety ex s71200 NON andrebbe bene
                {
                    reserveChannelNumbers.Add(reserveChannel);
                    _traceWriter.Write("RISERVA/RESERVE rilevata: '" + reserveRow.Description + "' su indirizzo " + reserveRow.Indirizzo + " -> canale " + reserveChannel);
                }
                else
                {
                    _traceWriter.Write("RISERVA/RESERVE su '" + item.Name + "': impossibile determinare il canale dall'indirizzo '" + reserveRow.Indirizzo + "'.");
                }
            }

            var channels = new List<SafetyChannelConfiguration>();

            // 1) Canali "normali": TUTTE le righe con Pin1 numerico, RISERVA comprese se per caso lo avessero
            var normalRows = rows
                .Where(r => int.TryParse(r.Pin1Raw, out _))
                .Select(r => (r.Description, Pin1: int.Parse(r.Pin1Raw), r.Pin2Raw))
                .ToList();

            foreach (var group in normalRows.GroupBy(r => r.Description))
            {
                var occurrences = group.ToList();

                if (occurrences.Count > 2)
                {
                    _traceWriter.Write("ATTENZIONE: il simbolo '" + group.Key + "' sul modulo '" + item.Name +
                        "' compare " + occurrences.Count + " volte (atteso 1 o 2). Verificare manualmente l'Excel.");
                }

                var evaluation = occurrences.Count >= 2 ? 1 : 0; 
                /* se compare 2 volte valutazione canalae doppio altrimneti canale singolo
                Failsafe_SensorEvaluation = 0 -> 1oo1 Evalutation
                Failsafe_SensorEvaluation = 1-> 1oo2 evalutation, equivalent
                Failsafe_SensorEvaluation = 2-> (1oo2 evalutation, non equivalent)
                Failsafe_SensorEvaluation = 3-> (Safety mat evalutation)
                */


                foreach (var occurrence in occurrences)
                {
                    var channelNumber = occurrence.Pin1 - 1;
                    var sensorSupply = !string.IsNullOrWhiteSpace(occurrence.Pin2Raw) ? channelNumber : 8;

                    _traceWriter.Write("Canale normale: '" + group.Key + "' -> canale " + channelNumber + " (Evaluation=" + evaluation + ", Supply=" + sensorSupply + ")");

                    channels.Add(new SafetyChannelConfiguration
                    {
                        ChannelNumber = channelNumber,
                        FailsafeSensorEvaluation = (UInt64)evaluation,
                        FailsafeSensorSupply = (UInt64)sensorSupply,
                        FailsafeActivated = true
                    });
                }
            }

            // 2) I canali RISERVA/RESERVE hanno SEMPRE precedenza: rimuovo eventuali duplicati "normali" sullo stesso canale
            channels.RemoveAll(c => reserveChannelNumbers.Contains(c.ChannelNumber));

            foreach (var reserveChannel in reserveChannelNumbers)
            {
              //  _traceWriter.Write("Canale normale: '" + group.Key + "' -> canale " + channelNumber + " (Evaluation=" + evaluation + ", Supply=" + sensorSupply + ")");
                
                channels.Add(new SafetyChannelConfiguration
                {
                    ChannelNumber = reserveChannel,
                    FailsafeSensorEvaluation = 0,
                    FailsafeSensorSupply = 8,
                    FailsafeActivated = false
                });
            }

            item.SafetyChannels = channels;
        }
        /// <summary>
        /// Estrae il numero di canale dalla parte "bit" di un indirizzo digitale (es. "100.5" -> canale 5).
        /// Usato per i canali RISERVA/RESERVE, dove il canale non si ricava da Pin1.
        /// </summary>
        private static bool TryGetChannelFromAddress(string indirizzo, out int channel)
        {
            channel = 0;
            if (string.IsNullOrWhiteSpace(indirizzo)) return false;

            var parts = indirizzo.Split('.');
            return parts.Length >= 2 && int.TryParse(parts[1], out channel);
        }

        private static bool TryGetDirection(string tipologia, out Direction direction)
        {
            switch (tipologia.Trim().ToUpperInvariant())
            {
                case "I":
                case "AIW":
                case "PEW":
                    direction = Direction.Input;
                    return true;
                case "Q":
                case "AQW":
                case "PAW":
                    direction = Direction.Output;
                    return true;
                default:
                    direction = Direction.Input;
                    return false;
            }
        }

        private static bool TryGetStartAddress(string indirizzo, out int startAddress)
        {
            // Digitale "0.0" -> prendo solo la parte byte (prima del punto)
            // Analogico "64" -> è già l'indirizzo di parola
            var bytePart = indirizzo.Split('.')[0];
            return int.TryParse(bytePart, out startAddress);
        }

        private enum AddressCategory { DigitalInput, DigitalOutput, AnalogInput, AnalogOutput }

        private static bool TryGetCategory(string tipologia, out AddressCategory category)
        {
            switch (tipologia.Trim().ToUpperInvariant())
            {
                case "I": category = AddressCategory.DigitalInput; return true;
                case "Q": category = AddressCategory.DigitalOutput; return true;
                case "AIW":
                case "PEW": category = AddressCategory.AnalogInput; return true;
                case "AQW":
                case "PAW": category = AddressCategory.AnalogOutput; return true;
                default: category = AddressCategory.DigitalInput; return false;
            }
        }

        private static string GetCellText(IRow row, int columnIndex)
        {
            var cell = row.GetCell(columnIndex);
            if (cell == null) return string.Empty;
            cell.SetCellType(CellType.String);
            return cell.StringCellValue?.Trim() ?? string.Empty;
        }

        private static string Normalize(string orderNumber)
        {
            if (string.IsNullOrEmpty(orderNumber)) return string.Empty;
            return orderNumber.Replace(" ", "").Replace("-", "").ToUpperInvariant();
        }
    }
}