using Basic_Project_Generator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Basic_Project_Generator.Services.PlcBlocks
{
    /// <summary>
    /// Genera il file XML (SimaticML) per un Global DB con uno Struct per ogni gruppo (sigla),
    /// da importare in TIA via PlcSoftware.BlockGroup.Blocks.Import(...).
    /// Schema verificato esportando manualmente un DB reale da TIA V19 (File > Export).
    /// </summary>
    public static class DbXmlGenerator
    {
        private static readonly XNamespace InterfaceNs = "http://www.siemens.com/automation/Openness/SW/Interface/v5";

        public static XDocument Generate(string dbName, int dbNumber, List<DbSymbolGroup> groups)
        {
            var sectionElement = new XElement(InterfaceNs + "Section", new XAttribute("Name", "Static"));

            foreach (var group in groups)
            {
                var structMember = new XElement(InterfaceNs + "Member",
                    new XAttribute("Name", group.Sigla),
                    new XAttribute("Datatype", "Struct"));

                foreach (var entry in group.Entries)
                {
                    structMember.Add(new XElement(InterfaceNs + "Member",
                        new XAttribute("Name", entry.Name),
                        new XAttribute("Datatype", "Bool")));
                }

                sectionElement.Add(structMember);
            }

            var sectionsElement = new XElement(InterfaceNs + "Sections", sectionElement);

            var document = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("Document",
                    new XElement("Engineering", new XAttribute("version", "V21")),
                    new XElement("SW.Blocks.GlobalDB", new XAttribute("ID", "0"),
                        new XElement("AttributeList",
                            new XElement("AutoNumber", "false"),
                            new XElement("Interface", sectionsElement),
                            new XElement("MemoryLayout", "Standard"),
                            new XElement("Name", dbName),
                            new XElement("Namespace"),
                            new XElement("Number", dbNumber),
                            new XElement("ProgrammingLanguage", "DB")



                        ),
                        BuildEmptyObjectListBoilerplate()
                    )
                )
            );

            return document;
        }

        /// <summary>
        /// Boilerplate copiato esattamente dall'export reale (Title/Comment del DB, vuoti).
        /// Necessario per un import valido, non personalizzato al momento.
        /// </summary>
        private static XElement BuildEmptyObjectListBoilerplate()
        {
            var cultures = new[] { "it-IT", "en-US"};

            XElement BuildMultilingualText(string id, string compositionName, string startId)
            {
                var items = cultures.Select((culture, index) =>
                    new XElement("MultilingualTextItem", new XAttribute("ID", (System.Convert.ToInt32(startId, 16) + index).ToString("X")),
                        new XAttribute("CompositionName", "Items"),
                        new XElement("AttributeList",
                            new XElement("Culture", culture),
                            new XElement("Text")
                        )));

                return new XElement("MultilingualText", new XAttribute("ID", id), new XAttribute("CompositionName", compositionName),
                    new XElement("ObjectList", items));
            }

            return new XElement("ObjectList",
                BuildMultilingualText("1", "Comment", "2"),
                BuildMultilingualText("E", "Title", "F")
            );
        }
    }
}