//Classe che rappresenta l'oggetto ExpModule 
/* per esempio vedi field
  DevieceCataolg
  			<TemplateName>DI 16x24VDC HF</TemplateName>
			<OrderNumber>6ES7521-1BH00-0AB0</OrderNumber>
			<FirmwareVersion>V2.1</FirmwareVersion>

*/
namespace Basic_Project_Generator.Models
{
    public class ExpModule
    {
        public string TemplateName { get; set; }
        public string OrderNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public int SlotNumber { get; set; }

        public string TypeIdentifier => "OrderNumber:" + OrderNumber + "/" + FirmwareVersion;
        public string Name => TemplateName;
    }
}