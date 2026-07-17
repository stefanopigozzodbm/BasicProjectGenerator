using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Basic_Project_Generator.Models
{
    public class DeviceModel
    {
        #region properties

        public int CurrentDeviceCount
        {
            get;
            set;
        }

        public Catalog DeviceCatalog
        {
            get;
            set;
        }

        public IList<DeviceItem> DeviceItemComposition
        {
            get;
            set;
        }

        #endregion // properties

        #region methods

        public void LoadDeviceCatalog(XDocument catalogDocument)
        {
            InitDeviceCatalog();

            var serializer = new XmlSerializer(typeof(Catalog));

            if (catalogDocument.Document != null)
            {
                using (var stringReader = new StringReader(catalogDocument.Document.ToString()))
                {
                    DeviceCatalog = (Catalog)serializer.Deserialize(stringReader);
                }
            }
        }

        private void InitDeviceCatalog()
        {
            if (DeviceCatalog != null && DeviceCatalog.DeviceItemComposition != null)
            {
                DeviceCatalog.DeviceItemComposition.Clear();
            }
        }

        public string GetNamePropertyName()
        {
            return nameof(DeviceItem.Name);
        }

        public string GetDeviceNamePropertyName()
        {
            return nameof(DeviceItem.DeviceName);
        }

        #endregion // methods
    }
}
