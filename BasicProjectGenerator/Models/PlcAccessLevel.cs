using System.Collections.Generic;

namespace Basic_Project_Generator.Models
{
    public class PlcAccessLevel
    {
        #region ctor

        // level 0 == PlcProtectionAccessLevel.None;    
        // level 1 == PlcProtectionAccessLevel.FullAccess;
        // level 2 == PlcProtectionAccessLevel.ReadAccess;
        // level 3 == PlcProtectionAccessLevel.HMIAccess;
        // level 4 == PlcProtectionAccessLevel.NoAccess;
        // level 5 == PlcProtectionAccessLevel.FullAccessIncludingFailsafe;
        public PlcAccessLevel(bool includeFailsafe)
        {
            AccessLevels = new List<AccessLevel>
            {
                new AccessLevel
                {
                    Name = "Full access (no protection)",
                    Tag = "FullAccess"
                }
            };

            if (includeFailsafe)
            {
                AccessLevels.Add(new AccessLevel
                {
                    Name = "Full access incl. fail-safe (no protection)",
                    Tag = "FullAccessIncludingFailsafe"
                });
            }
            AccessLevels.Add(new AccessLevel
            {
                Name = "Read access",
                Tag = "ReadAccess"
            });
            AccessLevels.Add(new AccessLevel
            {
                Name = "HMI access",
                Tag = "HMIAccess"
            });
            AccessLevels.Add(new AccessLevel
            {
                Name = "No access (complete protection)",
                Tag = "NoAccess"
            });
        }

        #endregion // ctor

        #region properties

        public List<AccessLevel> AccessLevels
        {
            get;
            set;
        }

        #endregion // properties

        #region methods

        public string GetNamePropertyName()
        {
            return nameof(AccessLevel.Name);
        }

        public string GetTagPropertyName()
        {
            return nameof(AccessLevel.Tag);
        }

        #endregion // methods
    }
}
