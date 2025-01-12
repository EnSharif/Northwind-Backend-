using Azure.Core;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUsersService _UsersService;
        private ITokenHelper _TokenHelper;

        public AuthManager(IUsersService usersService)
        {
            _UsersService = usersService;
        }

        public AuthManager(ITokenHelper tokenHelper)
        {
            _TokenHelper = tokenHelper;
        }


        public IDataResult<AccessToken> CreateAccessToken(Users users)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Users> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck=_UsersService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            { 
                return new ErrorDataResult<Users>(Messages.UserNotFound);    
            }

        }

        public IDataResult<Users> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
