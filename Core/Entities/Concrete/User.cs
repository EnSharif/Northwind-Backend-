using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
<<<<<<< HEAD:Core/Entities/Concrete/User.cs
        public bool Status { get; set; }
=======
        //public string Password { get; set; }
>>>>>>> d62e57d (API Authorize):Core/Entities/Concrete/Users.cs
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string LastName { get; set; }
    }
}