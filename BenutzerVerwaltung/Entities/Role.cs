using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenutzerVerwaltung.Entities
{
    public class Role 
    {
        public string RoleName { get; set; }

        public List<Permission> Permissions { get; set; }
      

        public Role()
        {
            Permissions = new List<Permission>();
          
        }
    }
}
