using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.Model
{
    public class AuthenticationService : IAuthenticationService
    {
        private class InternalUserData
        {
            public InternalUserData(string username, string email, string hashedPassword, string[] roles)
            {
                Username = username;
                Email = email;
                HashedPassword = hashedPassword;
                Roles = roles;
            }
            public string Username { get; private set; }
            public string Email { get; private set; }
            public string HashedPassword { get; private set; }
            public string[] Roles { get; private set; }
        }
        private static readonly List<InternalUserData> _users = new List<InternalUserData>()
            {
                new InternalUserData("Admin","Admin@company.com","sZInyAytP77DelrbyhCu9Qxs8MAxXu2OnsWzbZPzmOE=",new string []{"Administrator"}),
                new InternalUserData("Guest","Guest@company.com","sZInyAytP77DelrbyhCu9Qxs8MAxXu2OnsWzbZPzmOE=",new string []{})
            };
        public User AuthenticateUser(string username, string clearTextPassword)
        {
            InternalUserData UserDate = _users.FirstOrDefault(u => u.Username.Equals(username) && u.HashedPassword.Equals(CalculateHash(clearTextPassword, u.Username)));
            if (UserDate == null) throw new UnauthorizedAccessException("UnauthorizedAccessException");
            return new User(UserDate.Username, UserDate.Email, UserDate.Roles);
        }
        private string CalculateHash(string clearTextPassword, string salt)
        {
            byte[] saltHashByte = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltHashByte);
            string t= Convert.ToBase64String(hash); 
            return t;
        }
    }
    
}
