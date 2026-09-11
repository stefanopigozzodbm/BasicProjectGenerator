using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace Basic_Project_Generator
{
    public static class XmlResourceReader
    {
        public static XDocument LoadEmbeddedXml(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // ATTENZIONE: Questo deve corrispondere allo Spazio dei nomi predefinito del progetto + nome cartella
            string resourceName = $"Basic_Project_Generator.Assets.{fileName}";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    string available = string.Join("\n", assembly.GetManifestResourceNames());
                    throw new FileNotFoundException($"Risorsa '{resourceName}' non trovata. Risorse disponibili:\n{available}");
                }
                return XDocument.Load(stream);
            }
        }
    }
}