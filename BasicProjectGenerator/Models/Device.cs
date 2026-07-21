//Classe che rappresenta l'oggetto Device 
/* per esempio vedi field
  DevieceCataolg
  		<TemplateName>CPU 1516-3 - V1.8</TemplateName>			
			<Station>S7-1500/ET200MP station</Station>
			<DeviceName>PLC</DeviceName>
			<OrderNumber>6ES7 516-3AN00-0AB0</OrderNumber>
			<FirmwareVersion>V1.8</FirmwareVersion>
			<IncludeFailsafe>0</IncludeFailsafe>
	<!--(solo per PLC con IO onboard)PositionNumber dei dispositivi IO (IO/HSC/PTO) sulla cpu, numero univoco per capire l'Address in fase di assegnazione per chi è-->
			<IncludeHSC_1>16</IncludeHSC_1>
			<IncludeHSC_2>17</IncludeHSC_2>
			<IncludeHSC_3>18</IncludeHSC_3>
			<IncludeHSC_4>19</IncludeHSC_4>
			<IncludeHSC_5>20</IncludeHSC_5>
			<IncludeHSC_6>21</IncludeHSC_6>
			<IncludeAI2>2</IncludeAI2>
			<IncludeDI14DQ10>21</IncludeDI14DQ10>
			<IncludePTOPWM_1>32</IncludePTOPWM_1>
			<IncludePTOPWM_2>33</IncludePTOPWM_2>
			<IncludePTOPWM_3>34</IncludePTOPWM_3>
			<IncludePTOPWM_4>35</IncludePTOPWM_4>
*/


using Basic_Project_Generator.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Basic_Project_Generator.Models
{
    public class Device
    {
        #region properties

        public string Station { get; set; }
        public string TemplateName { get; set; }
        public string DeviceName { get; set; }
        public string OrderNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public bool IncludeFailsafe { get; set; }
        public int PositionNumber { get; set; }

        #endregion // properties

        #region onboard IO positions (solo per PLC con IO integrato: IO/HSC/PTO/PWM)

        // NOTA: queste proprietà restano pubbliche con getter/setter perché XmlSerializer
        // le popola per nome leggendo DeviceCatalog.xml. Non toccarle/rimuoverle.

        public int HSC_1 { get; set; }
        public int HSC_2 { get; set; }
        public int HSC_3 { get; set; }
        public int HSC_4 { get; set; }
        public int HSC_5 { get; set; }
        public int HSC_6 { get; set; }
        public int AI2 { get; set; }
        public int DI14DQ10 { get; set; }
        public int PTOPWM_1 { get; set; }
        public int PTOPWM_2 { get; set; }
        public int PTOPWM_3 { get; set; }
        public int PTOPWM_4 { get; set; }

        #endregion // onboard IO positions

        #region Costant Fields
            public int? HSC_1_Address { get; set; }
            public int? HSC_2_Address { get; set; }
            public int? HSC_3_Address { get; set; }
            public int? HSC_4_Address { get; set; }
            public int? HSC_5_Address { get; set; }
            public int? HSC_6_Address { get; set; }
            public int? PTOPWM_1_Address { get; set; }
            public int? PTOPWM_2_Address { get; set; }
            public int? PTOPWM_3_Address { get; set; }
            public int? PTOPWM_4_Address { get; set; }

       

        /// <summary>Indirizzo costante configurato per un blocco onboard (es. "HSC_2"); null se non configurato.</summary>
        public int? GetOnboardConstantAddress(string onboardName)
        {
            switch (onboardName)
            {
                case "HSC_1": return HSC_1_Address;
                case "HSC_2": return HSC_2_Address;
                case "HSC_3": return HSC_3_Address;
                case "HSC_4": return HSC_4_Address;
                case "HSC_5": return HSC_5_Address;
                case "HSC_6": return HSC_6_Address;
                case "PTOPWM_1": return PTOPWM_1_Address;
                case "PTOPWM_2": return PTOPWM_2_Address;
                case "PTOPWM_3": return PTOPWM_3_Address;
                case "PTOPWM_4": return PTOPWM_4_Address;
                default: return null;
            }
        }
        #endregion

        #region computed properties

        public string TypeIdentifier => "OrderNumber:" + OrderNumber + "/" + FirmwareVersion;
        public string TypeName => Station + "_" + (PositionNumber + 1).ToString();
        public string Name => DeviceName;

        #endregion // computed properties

#region methods

/*MemberwiseClone() copia tutte le proprietà automaticamente 
 * (va bene qui perché sono tutti tipi semplici: string, int, bool 
 * — nessun oggetto complesso da clonare in profondità), 
 * quindi non c'è più bisogno di elencarle a mano né di ricordarsi
 * di aggiornare questo punto quando aggiungi campi futuri.*/
public Device Clone()
{
    return (Device)MemberwiseClone();
}

//aggiunti metodi per essere passati verso AddNewDevice e poi Do AddNewDevice su ApiWrapper per avere dati più specificfici
//relativamente alla configurazione di periferiche HSC, AI, DI/DQ, PTO/PWM onboard alla CPu ( ovvimenate se no presetni non servono)


/// <summary>
/// Restituisce le posizioni IO integrate (HSC/AI/DI-DQ/PTO-PWM) come dizionario ordinato Nome -> PositionNumber.
/// Le voci con valore 0 vengono escluse (0 = non presente su questo modello di CPU).
/// </summary>
public IReadOnlyDictionary<string, int> GetOnboardIoByName()
{
    var ordered = new Dictionary<string, int>
    {
        { nameof(HSC_1), HSC_1 },
        { nameof(HSC_2), HSC_2 },
        { nameof(HSC_3), HSC_3 },
        { nameof(HSC_4), HSC_4 },
        { nameof(HSC_5), HSC_5 },
        { nameof(HSC_6), HSC_6 },
        { nameof(AI2), AI2 },
        { nameof(DI14DQ10), DI14DQ10 },
        { nameof(PTOPWM_1), PTOPWM_1 },
        { nameof(PTOPWM_2), PTOPWM_2 },
        { nameof(PTOPWM_3), PTOPWM_3 },
        { nameof(PTOPWM_4), PTOPWM_4 }
    };

    return new ReadOnlyDictionary<string, int>(
        ordered.Where(kv => kv.Value != 0)
               .ToDictionary(kv => kv.Key, kv => kv.Value));
}

        /// <summary>
        /// Restituisce la mappatura inversa PositionNumber -> Nome, utile per risalire dal PositionNumber
        /// di un DeviceItem (letto durante l'assegnazione indirizzi) al nome del blocco IO integrato corrispondente.
        /// Essendo il PositionNumber univoco per ogni blocco su una data CPU, la mappatura è 1:1.
        /// </summary>
        public IReadOnlyDictionary<int, string> GetOnboardIoByPosition()
        {
            var byName = GetOnboardIoByName();

            var duplicates = byName
                .GroupBy(kv => kv.Value)
                .Where(g => g.Count() > 1)
                .ToList();

            foreach (var dup in duplicates)
            {
               
               Debug.WriteLine("PositionNumber duplicato: " + dup.Key + " usato da: " + string.Join(", ", dup.Select(kv => kv.Key)));
            }

            return new ReadOnlyDictionary<int, string>(byName.ToDictionary(kv => kv.Value, kv => kv.Key));
        }

        /// <summary>
        /// Restituisce il nome del blocco IO integrato (es. "HSC_2") corrispondente al PositionNumber dato,
        /// oppure null se non trovato (es. per moduli aggiunti manualmente, non integrati nella CPU).
        /// </summary>
        public string GetOnboardIoName(int positionNumber)
{
    return GetOnboardIoByPosition().TryGetValue(positionNumber, out var name) ? name : null;
}

#endregion // methods
}
}
