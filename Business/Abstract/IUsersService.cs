using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUsersService
    {
        List<OperationClaim> GetClaims(Users users);

        void Add(Users users);
        Users GetByMail(string email);
    }
}
