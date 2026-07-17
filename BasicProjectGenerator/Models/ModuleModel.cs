using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Basic_Project_Generator.Models
{
    public class ModuleModel
    {
        public ModuleCatalog ModuleCatalog { get; set; }

        public void LoadModuleCatalog(XDocument catalogDocument)
        {
            var serializer = new XmlSerializer(typeof(ModuleCatalog));
            using (var stringReader = new StringReader(catalogDocument.Document.ToString()))
            {
                ModuleCatalog = (ModuleCatalog)serializer.Deserialize(stringReader);
            }
        }

        public string GetNamePropertyName() => nameof(Module.TemplateName);
    }
}