using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Text;
=======
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> d62e57d (API Authorize)

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
<<<<<<< HEAD
        public static void CreatePasswordHash(string passowrd, out byte[] passwordHash, out byte[] passwordSalt)
=======
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
>>>>>>> d62e57d (API Authorize)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
<<<<<<< HEAD
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passowrd));
            }
        }

=======
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
>>>>>>> d62e57d (API Authorize)
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
<<<<<<< HEAD
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != passwordHash[i])
=======
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
>>>>>>> d62e57d (API Authorize)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
<<<<<<< HEAD
    }
}
=======

    }
}
>>>>>>> d62e57d (API Authorize)
