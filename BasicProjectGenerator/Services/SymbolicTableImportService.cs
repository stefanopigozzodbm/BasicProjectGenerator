using Basic_Project_Generator.Models;
using NPOI.SS.UserModel;
using System.Collections.Generic;
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

        private enum Direction { Input, Output }

        public List<ImportedSymbolItem> Import(string filePath, Catalog deviceCatalog, ModuleCatalog moduleCatalog)
        {
            var result = new List<ImportedSymbolItem>();
            ImportedSymbolItem currentItem = null;

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
                        // Inizia una nuova scheda: creo il nuovo item corrente
                        currentItem = new ImportedSymbolItem
                        {
                            Name = GetCellText(row, ColumnSiglaScheda),
                            OrderNumber = orderNumber,
                            ItemType = SymbolItemType.Unknown
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
                            }
                        }

                        result.Add(currentItem);
                        continue;
                    }

                    // Riga di I/O appartenente alla scheda corrente
                    if (currentItem == null) continue;

                    var tipologia = GetCellText(row, ColumnTipologia);
                    var indirizzo = GetCellText(row, ColumnIndirizzo);

                    if (string.IsNullOrWhiteSpace(tipologia) || string.IsNullOrWhiteSpace(indirizzo)) continue;

                    if (TryGetDirection(tipologia, out var direction) && TryGetStartAddress(indirizzo, out var startAddress))
                    {
                        if (direction == Direction.Input && currentItem.InputStartAddress == null)
                        {
                            currentItem.InputStartAddress = startAddress;
                        }
                        else if (direction == Direction.Output && currentItem.OutputStartAddress == null)
                        {
                            currentItem.OutputStartAddress = startAddress;
                        }
                    }
                }
            }

            return result;
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