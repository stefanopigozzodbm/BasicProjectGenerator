namespace Basic_Project_Generator.Models.Configuration
{
    /// <summary>Configurazione di catalogo per uno slave IO-Link (espansione o sensore/attuatore).</summary>
    public class IOLinkSlaveModule
    {
        public string Code { get; set; }
        public string MasterCopyName { get; set; }
    }
}