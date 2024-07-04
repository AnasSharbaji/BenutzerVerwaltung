using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenutzerVerwaltung.Entities
{
    public class User
    {
     
        
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FullName => $"{FirstName} {LastName}";
            public string Email { get; set; }
            public string Address { get; set; }
            public string Password { get; set; }
            public List<Role> Roles { get; set; }
            public List<Group> Groups { get; set; }

            public User()
            {
                Roles = new List<Role>();
                Groups = new List<Group>();

            }
    }
    
}
