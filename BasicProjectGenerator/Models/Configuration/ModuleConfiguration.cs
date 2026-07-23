//classe creata come aggiornamento per aggiungere la configurazione safety dei canali di un modulo F-DI
//senza dovere passsare separatamente tutti i parametri al richiamo dell adnewmodeule sul apiwraper

using System.Collections.Generic;

namespace Basic_Project_Generator.Models
{
    /// <summary>Incapsula tutti i parametri necessari per aggiungere un modulo di espansione (DoAddNewModule).</summary>
    public class ModuleConfiguration
    {
        public string TypeIdentifier { get; set; }
        public string Name { get; set; }
        public int? InputStartAddress { get; set; }
        public int? OutputStartAddress { get; set; }
        public bool NewPotentialGroup { get; set; }
        public List<SafetyChannelConfiguration> SafetyChannels { get; set; } = new List<SafetyChannelConfiguration>();
    }
}