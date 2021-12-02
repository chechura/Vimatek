using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.Model
{
    public class CustomIdentity : IIdentity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string[] Role { get; private set; }

        public CustomIdentity(string name, string email, string[] role)
        {
            Name = name;
            Email = email;
            Role = role;
        }

        public string AuthenticationType { get { return "Custom authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }


    }
}
