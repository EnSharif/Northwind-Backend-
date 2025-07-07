using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
<<<<<<< HEAD
using Entities.Concrete;
=======
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> d62e57d (API Authorize)

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
<<<<<<< HEAD
            _userDal.Add(user);
=======
            return _userDal.Get(filter: u => u.Email == email);
>>>>>>> d62e57d (API Authorize)
        }

        public User GetByEmail(string email)
        {
            return _userDal.Get(filter: u => u.Email == email);
        }
    }
}