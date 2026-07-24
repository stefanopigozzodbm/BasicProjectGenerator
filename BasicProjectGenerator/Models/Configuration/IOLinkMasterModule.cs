namespace Basic_Project_Generator.Models.Configuration
{
    /// <summary>
    /// Configurazione di catalogo per un master IO-Link (letta da IOLink_StartupSettings.xml).
    /// Gli indirizzi/IP/DeviceNumber per la N-esima occorrenza dello stesso master nel progetto
    /// si calcolano a runtime come Base + occurrenceIndex * Step (occurrenceIndex parte da 0).
    /// </summary>
    public class IOLinkMasterModule
    {
        public string Code { get; set; }
        public string MasterCopyName { get; set; }
        public int BaseInputStartAddress { get; set; }
        public int BaseOutputStartAddress { get; set; }
        public int AddressStep { get; set; }
        public int BaseIpLastOctet { get; set; }
        public int BaseDeviceNumber { get; set; }
        public int IpDeviceStep { get; set; }

        public int GetInputStartAddress(int occurrenceIndex) => BaseInputStartAddress + occurrenceIndex * AddressStep;
        public int GetOutputStartAddress(int occurrenceIndex) => BaseOutputStartAddress + occurrenceIndex * AddressStep;
        public int GetIpLastOctet(int occurrenceIndex) => BaseIpLastOctet + occurrenceIndex * IpDeviceStep;
        public int GetDeviceNumber(int occurrenceIndex) => BaseDeviceNumber + occurrenceIndex * IpDeviceStep;
    }
}