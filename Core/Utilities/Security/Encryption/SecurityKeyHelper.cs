using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    //public class SecurityKeyHelper
    //{
    //    public static SecurityKey CreateSecurtyKey(string securtyKey)
    //    {
    //        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securtyKey));
    //    }
    //}
    public static class SecurityKeyHelper
    {
<<<<<<< HEAD
        public static SecurityKey CreateSecurityKey(string securtyKey)
=======
        public static SecurityKey CreateSecurtyKey(string securityKey)
>>>>>>> d62e57d (API Authorize)
        {
            if (string.IsNullOrEmpty(securityKey))
                throw new ArgumentException("Security key cannot be null or empty.", nameof(securityKey));

            // Für Textschlüssel
            if (securityKey.Length < 32)
                throw new ArgumentException("Security key must be at least 32 characters long for HMACSHA256.");

            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }


}
