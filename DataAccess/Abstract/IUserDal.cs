using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}

//public class User : IEntity
//{
//    public int Id { get; set; }
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public string Email { get; set; }
//    public bool Status { get; set; }
//    public byte[] PasswordHash { get; set; }
//    public byte[] PasswordSalt { get; set; }
//}
