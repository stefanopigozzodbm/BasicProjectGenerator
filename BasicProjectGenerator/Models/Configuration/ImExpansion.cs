//Classe che rappresenta l'oggetto ImExpansion
/* per esempio vedi field
  ImExpansione
  			<ImExpansion>
			<TemplateName>IM 155-6 PN ST (6AU00)</TemplateName>
			<OrderNumber>6ES7 155-6AU00-0BN0</OrderNumber>
			<IsSafety>false</IsSafety>
			<FirmwareVersion>V3.3</FirmwareVersion>
			<BaseIpLastOctet>20</BaseIpLastOctet>
			<BaseDeviceNumber>20</BaseDeviceNumber>
			<IpDeviceStep>1</IpDeviceStep>
		    </ImExpansion>

*/

namespace Basic_Project_Generator.Models
{
    public class ImExpansion
    {
        public string TemplateName { get; set; }
        public string OrderNumber { get; set; }
        public bool IsSafety { get; set; }
        public string FirmwareVersion { get; set; }
        public int BaseIpLastOctet { get; set; }
        public int BaseDeviceNumber { get; set; }
        public int IpDeviceStep { get; set; }
        public string SubnetIp { get; set; }

        public string TypeIdentifier => "OrderNumber:" + OrderNumber + "/" + FirmwareVersion;
        public string Name => TemplateName;

        public int GetIpLastOctet(int occurrenceIndex) => BaseIpLastOctet + occurrenceIndex * IpDeviceStep;
        public int GetDeviceNumber(int occurrenceIndex) => BaseDeviceNumber + occurrenceIndex * IpDeviceStep;
    }
}