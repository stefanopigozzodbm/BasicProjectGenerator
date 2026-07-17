//Classe che rappresenta l'oggetto Device 
/* per esempio vedi field
  DevieceCataolg
  		<TemplateName>CPU 1516-3 - V1.8</TemplateName>			
			<Station>S7-1500/ET200MP station</Station>
			<DeviceName>PLC</DeviceName>
			<OrderNumber>6ES7 516-3AN00-0AB0</OrderNumber>
			<FirmwareVersion>V1.8</FirmwareVersion>
			<IncludeFailsafe>0</IncludeFailsafe>

*/

namespace Basic_Project_Generator.Models
{
    public class Device
    {
        #region properties

        public string Station
        {
            get;
            set;
        }

        public string TemplateName
        {
            get;
            set;
        }

        public string DeviceName
        {
            get;
            set;
        }

        public string OrderNumber
        {
            get;
            set;
        }

        public string FirmwareVersion
        {
            get;
            set;
        }

        public bool IncludeFailsafe
        {
            get;
            set;
        }

        public int PositionNumber
        {
            get;
            set;
        }

        public string TypeIdentifier => "OrderNumber:" + OrderNumber + "/" + FirmwareVersion;

        public string TypeName => Station + "_" + (PositionNumber + 1).ToString();

        public string Name => DeviceName;

        #endregion // properties
    }
}
