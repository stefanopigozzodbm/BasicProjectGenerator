using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UmacRoleAssignment
{
    public string Name { get; set; }
    public bool Enable { get; set; }
}

public class UmacUserSettings
{
    public string Name { get; set; }
    public bool IsProjectProtectionUser { get; set; } // da <Type>
    public string Password { get; set; }
    public int Timeout { get; set; }
    public List<UmacRoleAssignment> Roles { get; set; } = new List<UmacRoleAssignment>(); // indice = Number
}