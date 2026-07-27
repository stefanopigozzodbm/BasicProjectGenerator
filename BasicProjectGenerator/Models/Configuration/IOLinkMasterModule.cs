using System.Collections.Generic;
using System.Linq; // Aggiunto per poter utilizzare metodi utili come FirstOrDefault e Any

namespace Basic_Project_Generator.Models.Configuration
{
    /// <summary>
    /// Configurazione di catalogo per un master IO-Link (letta da IOLink_StartupSettings.xml).
    /// </summary>
    public class IOLinkMasterModule
    {
        public string MasterCopyName { get; set; }
        public string Code { get; set; }
        public int BaseInputStartAddress { get; set; }
        public int BaseOutputStartAddress { get; set; }
        public int AddressStep { get; set; }
        public int BaseIpLastOctet { get; set; }
        public string SubnetIp { get; set; }
        public int BaseDeviceNumber { get; set; }
        public int IpDeviceStep { get; set; }

        /// <summary>   
        /// Lista degli slave connessi a questo master.
        /// </summary>
        public List<IOLinkSlaveModule> SlaveModules { get; set; } = new List<IOLinkSlaveModule>();

        public int GetInputStartAddress(int occurrenceIndex) => BaseInputStartAddress + occurrenceIndex * AddressStep;
        public int GetOutputStartAddress(int occurrenceIndex) => BaseOutputStartAddress + occurrenceIndex * AddressStep;
        public int GetIpLastOctet(int occurrenceIndex) => BaseIpLastOctet + occurrenceIndex * IpDeviceStep;
        public int GetDeviceNumber(int occurrenceIndex) => BaseDeviceNumber + occurrenceIndex * IpDeviceStep;

        // ==========================================
        // METODI RICHIESTI
        // ==========================================

        /// <summary>
        /// Inserisce un nuovo slave nella lista.
        /// </summary>
        public void AddSlave(IOLinkSlaveModule slave)
        {
            if (slave != null)
            {
                SlaveModules.Add(slave);
            }
        }

        /// <summary>
        /// Rimuove un'istanza specifica di uno slave dalla lista.
        /// Restituisce true se la rimozione ha avuto successo.
        /// </summary>
        public bool RemoveSlave(IOLinkSlaveModule slave)
        {
            return SlaveModules.Remove(slave);
        }

        /// <summary>
        /// Restituisce il numero totale di slave attualmente assegnati a questo master.
        /// </summary>
        public int GetSlavesCount()
        {
            return SlaveModules.Count;
        }

        /// <summary>
        /// Resetta la lista degli slave svuotandola completamente.
        /// </summary>
        public void ClearSlaves()
        {
            SlaveModules.Clear();
        }

        // ==========================================
        // METODI EXTRA PROPOSTI E CORREZIONI
        // ==========================================

        /// <summary>
        /// CORREZIONE: Cerca lo slave tramite il numero di porta in modo sicuro.
        /// NOTA: Presuppone che la classe IOLinkSlaveModule abbia una proprietà chiamata 'PortNumber'.
        /// </summary>
        public IOLinkSlaveModule GetIOLinkSlaveModuleByPortNumber(int portNumber)
        {
            return SlaveModules.FirstOrDefault(s => s.PortNumber == portNumber);
        }

        /// <summary>
        /// PROPOSTA: Rimuove uno slave conoscendo solo il suo numero di porta.
        /// Spesso in fase di configurazione non hai l'oggetto in memoria, ma sai quale porta vuoi liberare.
        /// </summary>
        public bool RemoveSlaveByPort(int portNumber)
        {
            var slaveToRemove = GetIOLinkSlaveModuleByPortNumber(portNumber);
            if (slaveToRemove != null)
            {
                return SlaveModules.Remove(slaveToRemove);
            }
            return false;
        }

        /// <summary>
        /// PROPOSTA: Verifica se una determinata porta è già occupata da uno slave.
        /// Utile prima di fare un AddSlave per evitare conflitti o sovrascritture.
        /// </summary>
        public bool IsPortOccupied(int portNumber)
        {
            return SlaveModules.Any(s => s.PortNumber == portNumber);
        }
    }
}