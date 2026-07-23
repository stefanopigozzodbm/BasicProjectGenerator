//classe per oggetto che descrive la configurazione safety di un singolo canale di un modulo F-DI
//probabilmente non funziona con s71200 in quanto non ci sono attributi sul channel safety cambiabili da openness
using System;

namespace Basic_Project_Generator.Models
{
    /// <summary>Configurazione Safety per un singolo canale di un modulo F-DI.</summary>
    public class SafetyChannelConfiguration
    {
        public int ChannelNumber { get; set; }

        // 0 = canale singolo, 1 = 1oo2 equivalent Failsafe_SensorEvaluation = 2 -> (1oo2 evalutation, non equivalent)
        // Failsafe_SensorEvaluation = 3 -> (Safety mat evalutation)
        public UInt64 FailsafeSensorEvaluation { get; set; } 
      
        public Boolean Failsafe_Activated { get; set; }

        public UInt64 FailsafeSensorSupply { get; set; }      // 0-7 = sensor supply N, 8 = external
    }
}