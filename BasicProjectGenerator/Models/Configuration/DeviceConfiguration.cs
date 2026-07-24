//analoga a modulo configuration ma contine i parametri di configurazione del plc (doaddnewdevice)
using System.Collections.Generic;

namespace Basic_Project_Generator.Models
{
    /// <summary>Incapsula tutti i parametri necessari per aggiungere un PLC (DoAddNewDevice).</summary>
    public class DeviceConfiguration
    {
        public string TypeIdentifier { get; set; }
        public string Name { get; set; }
        public string DeviceName { get; set; }
        public Device CatalogDevice { get; set; }
        public int? DigitalInputStartAddress { get; set; }
        public int? DigitalOutputStartAddress { get; set; }
        public int? AnalogInputStartAddress { get; set; }
        public int? AnalogOutputStartAddress { get; set; }
        public IReadOnlyDictionary<int, string> IntPeriphName { get; set; }
        public Dictionary<string, object> StartupAttributes { get; set; }
        public Dictionary<string, object> StartupIpAddresses { get; set; }
    }
}