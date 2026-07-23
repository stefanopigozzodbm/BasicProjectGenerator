//corrisponde al singolo codice d'ordine letto dall'excel
//percui con indirizzo di partenza (per i o q dipende)
//se analogico (i/O) predne il valore in word altrimenti se digitale prende il byte
using System.Collections.Generic;

namespace Basic_Project_Generator.Models
{
    public enum SymbolItemType
    {
        Unknown,
        Device,
        Module
    }

    public class ImportedSymbolItem
    {
        public string Name { get; set; }
        public string OrderNumber { get; set; }
        public string TypeIdentifier { get; set; }
        public SymbolItemType ItemType { get; set; }
        public Device MatchedDevice { get; set; }
        public bool IsSafetyModule { get; set; }
        public List<SafetyChannelConfiguration> SafetyChannels { get; set; } = new List<SafetyChannelConfiguration>();
        public int? DigitalInputStartAddress { get; set; }
        public int? DigitalOutputStartAddress { get; set; }
        public int? AnalogInputStartAddress { get; set; }
        public int? AnalogOutputStartAddress { get; set; }
        public bool NewPotentialGroup { get; set; }  // colonna J: true=1 (nuovo gruppo), false=0

        // Compatibilità con AddNewModule esistente (moduli: sempre puramente digitali o analogici)
        public int? InputStartAddress => DigitalInputStartAddress ?? AnalogInputStartAddress;
        public int? OutputStartAddress => DigitalOutputStartAddress ?? AnalogOutputStartAddress;


    }
}