namespace Basic_Project_Generator.Models.Configuration
{
    /// <summary>
    /// Tiene traccia del prossimo indirizzo libero (Input/Output) per un singolo master IO-Link,
    /// mentre si aggiungono i suoi slave in sequenza. Inizializzato dal valore di partenza del catalogo,
    /// avanzato dopo ogni slave piazzato in base alla Length (in bit) del suo Address.
    /// </summary>
    public class IOLinkAddressCursor
    {
        public int NextInputAddress { get; set; }
        public int NextOutputAddress { get; set; }
    }
}