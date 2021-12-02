using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.Model
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity _Identity;
        public CustomIdentity Identity
        {
            get
            {
                return _Identity ?? new AnonymousIdentity();
            }
            set
            {
                _Identity = value;
            }
        }

        IIdentity IPrincipal.Identity => this.Identity;

        public bool IsInRole(string role)
        {
            return _Identity.Role.Contains(role);
        }
    }
}
