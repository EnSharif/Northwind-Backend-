<<<<<<< HEAD
﻿using System;
using Business.Abstract;
using Entities.Dtos;
=======
﻿using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
>>>>>>> d62e57d (API Authorize)
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
<<<<<<< HEAD
        private readonly IAuthService _authService;
=======
        private IAuthService _authService;
>>>>>>> d62e57d (API Authorize)

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
<<<<<<< HEAD

            if (!userToLogin.Success)
                return BadRequest(userToLogin.Message);

            var accessTokenResult = _authService.CreateAccessToken(userToLogin.Data);

            if (accessTokenResult.Success)
                return Ok(accessTokenResult.Data);

            return BadRequest(accessTokenResult.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
                return BadRequest(userExists.Message);

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            // Kullanıcı oluşturulamadıysa (Data null döndüyse)
            if (!registerResult.Success || registerResult.Data == null)
                return BadRequest(registerResult.Message ?? "Kullanıcı oluşturulamadı.");

            var accessTokenResult = _authService.CreateAccessToken(registerResult.Data);

            if (accessTokenResult.Success)
                return Ok(accessTokenResult.Data);

            return BadRequest(accessTokenResult.Message);
        }
    }
=======
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        
        }

    }

>>>>>>> d62e57d (API Authorize)
}
