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
