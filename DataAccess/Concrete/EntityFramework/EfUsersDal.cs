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
    public class EfUsersDal : EfEntityRepositoryBase<Users, NortwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(Users users)
        {
            using (var context = new NortwindContext())
            {
                var result = from OperationClaim in context.operationClaims
                             join UsersOperationClaims in context.usersOperationClaims
                             on OperationClaim.Id equals UsersOperationClaims.Id
                             where UsersOperationClaims.UserId == users.Id
                             select new OperationClaim { Id = UsersOperationClaims.Id, Name = OperationClaim.Name };
                return result.ToList();
            }
        }


    }
}
