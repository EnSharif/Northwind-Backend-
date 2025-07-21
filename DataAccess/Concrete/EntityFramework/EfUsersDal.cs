using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUsersDal : EfEntityRepositoryBase<User, NortwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NortwindContext())
            {
                var result = from OperationClaim in context.operationClaim
                             join UserOperationClaim in context.userOperationClaim
                             on OperationClaim.Id equals UserOperationClaim.Id
                             where UserOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = UserOperationClaim.Id, Name = OperationClaim.Name };
                return result.ToList();
            }
        }


    }
}
