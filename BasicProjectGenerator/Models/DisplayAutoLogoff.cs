using System.Collections.Generic;

namespace Basic_Project_Generator.Models
{
    public class DisplayAutoLogoff
    {
        #region ctor

        public DisplayAutoLogoff()
        {
            AutoLogoffs = new List<AutoLogoff>
            {
                new AutoLogoff {Name = "Disable", Tag = "Disabled"},
                new AutoLogoff {Name = "1 minute", Tag = "Value1Minute"},
                new AutoLogoff {Name = "2 minutes", Tag = "Value2Minutes"},
                new AutoLogoff {Name = "5 minutes", Tag = "Value5Minutes"},
                new AutoLogoff {Name = "10 minutes", Tag = "Value10Minutes"},
                new AutoLogoff {Name = "15 minutes", Tag = "Value15Minutes"},
                new AutoLogoff {Name = "30 minutes", Tag = "Value30Minutes"},
                new AutoLogoff {Name = "1 hour", Tag = "Value1Hour"}
            };
        }

        #endregion // ctor

        #region properties

        public List<AutoLogoff> AutoLogoffs
        {
            get;
            set;
        }

        #endregion // properties

        #region methods

        public string GetNamePropertyName()
        {
            return nameof(AutoLogoff.Name);
        }

        public string GetTagPropertyName()
        {
            return nameof(AutoLogoff.Tag);
        }

        #endregion // methods
    }
}
