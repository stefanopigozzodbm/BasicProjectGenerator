using System.Collections.Generic;

namespace Basic_Project_Generator.Models
{
    /// <summary>
    /// Un singolo bool da inserire nel DB, nell'ordine in cui deve comparire nello Struct.
    /// </summary>
    public class  DbSymbolEntry
    {
        public string Name { get; set; } // per ora "xxx-" + descrizione,sarebbe la vera sigla del sensore manon c'è sul simbolico da IDEA..ma perchè?
    }

    /// <summary>
    /// Raggruppamento per sigla del dispositvo IOlinkMaster (come Xi/XO) oppure IOlinkSlave 
    /// </summary>
    public class DbSymbolGroup
    {
        public string Sigla { get; set; }
        public List<DbSymbolEntry> Entries { get; set; } = new List<DbSymbolEntry>();
    }
}