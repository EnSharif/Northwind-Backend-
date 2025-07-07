using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {

            using (var context = new NorthwindContext())
            {
                var result = from OperationClaims in context.OperationClaim
                             join UserOperationClaims in context.UserOperationClaim
                             on OperationClaims.Id equals UserOperationClaims.OperationClaimId
                             where UserOperationClaims.UserId == user.Id
                             select new OperationClaim { Id = OperationClaims.Id, Name = OperationClaims.Name };
                return result.ToList();
            }

        }
    }
}