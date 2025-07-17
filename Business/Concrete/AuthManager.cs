using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _UsersService;
        private ITokenHelper _TokenHelper;

        public AuthManager(IUserService usersService, ITokenHelper tokenHelper)
        {
            _UsersService = usersService;
            _TokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User users)
        {
            var claims = _UsersService.GetClaims(users);
            var accessToken = _TokenHelper.CreateToken(users, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }


        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck =_UsersService.GetByMail(userForLoginDto.Email);
            if(userToCheck==null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswoerError);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_UsersService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash,out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _UsersService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        
    }

}
