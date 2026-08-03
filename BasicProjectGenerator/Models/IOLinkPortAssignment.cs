namespace Basic_Project_Generator.Models
{
    public enum IOLinkPortKind { Empty, Expansion, Sensor }

    /// <summary>Cosa è collegato a una specifica porta (1-8) di un master IO-Link, letto dall'Excel.</summary>
    public class IOLinkPortAssignment
    {
        public int PortNumber { get; set; }      // 1-8, coerente con CheckPortCanPlugMove
        public IOLinkPortKind Kind { get; set; }
        public string Code { get; set; }         // es. "AL2401", "TP3232" -> chiave di lookup nel catalogo slave
        public string InstanceName { get; set; } // nome da assegnare all'istanza piazzata (sigla o D-L_J)
    }
}