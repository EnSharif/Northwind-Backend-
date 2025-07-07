<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
=======
﻿using Business.Abstract;
>>>>>>> d62e57d (API Authorize)
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

>>>>>>> d62e57d (API Authorize)


namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

<<<<<<< HEAD
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);

            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(userToCheck, Messages.UserNotFound); ;
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(userToCheck, Messages.PasswordError); ;
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin); ;
=======
        public AuthManager(IUsersService usersService, ITokenHelper tokenHelper)
        {
            _UsersService = usersService;
            _TokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(Users users)
        {
            var claims = _UsersService.GetClaims(users);
            var accessToken = _TokenHelper.CreateToken(users, claims);
            return new SucessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }


        public IDataResult<Users> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck =_UsersService.GetByMail(userForLoginDto.Email);
            if(userToCheck==null)
            {
                return new ErrorDataResult<Users>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Users>(Messages.PasswoerError);
            }
            return new SucessDataResult<Users>(userToCheck, Messages.SuccessfulLogin);
>>>>>>> d62e57d (API Authorize)
        }

        public IResult UserExists(string email)
        {
<<<<<<< HEAD
            if (_userService.GetByEmail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {

                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        // No changes needed in the method itself
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);

            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
=======
            if (_UsersService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
>>>>>>> d62e57d (API Authorize)
        }

        public IDataResult<Users> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash,out passwordSalt);
            var user = new Users
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _UsersService.Add(user);
            return new SucessDataResult<Users>(user, Messages.UserRegistered);
        }

        
    }
<<<<<<< HEAD
}
=======

}
>>>>>>> d62e57d (API Authorize)
