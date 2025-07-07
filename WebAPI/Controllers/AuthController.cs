using System;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);

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
}
