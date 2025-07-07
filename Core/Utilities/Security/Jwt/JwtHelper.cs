using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
<<<<<<< HEAD
        public IConfiguration Configration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configration = configuration;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>()
                            ?? throw new ArgumentNullException(nameof(_tokenOptions), "Token options cannot be null.");
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaim)
        {
            // ➤ HATA BURADA DÜZELTİLDİ: access token süresi artık burada hesaplanıyor
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            var jwt = CreateJwtSecurtyToken(_tokenOptions, user, signingCredentials, operationClaim);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

=======

        //public IConfiguration Configration { get; }
        //private TokenOptions _tokenOptions;
        //DateTime _accessTokenExpiration;
        public IConfiguration Configration { get; }
        private readonly TokenOptions _tokenOptions;
        private readonly DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configration)
        {
            Configration = configration;
            _tokenOptions = configration.GetSection(key: "TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }


        public AccessToken CreateToken(Users users, List<OperationClaim> operationClaims)
        {
            var securtyKey = SecurityKeyHelper.CreateSecurtyKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securtyKey);
            var jwt = CreateJwtSecurtyToken(_tokenOptions, users, signingCredentials, operationClaims);
            var jwtSecurtyTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurtyTokenHandler.WriteToken(jwt);
>>>>>>> d62e57d (API Authorize)
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

<<<<<<< HEAD
        public JwtSecurityToken CreateJwtSecurtyToken(TokenOptions tokenOptions, User user,
                                                      SigningCredentials signingCredentials,
                                                      List<OperationClaim> operationClaim)
=======
        public JwtSecurityToken CreateJwtSecurtyToken(TokenOptions tokenOptions, Users users,
                                  SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
>>>>>>> d62e57d (API Authorize)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
<<<<<<< HEAD
                notBefore: DateTime.Now,
                expires: _accessTokenExpiration,
                claims: SetClaims(user, operationClaim),
                signingCredentials: signingCredentials
            );
=======
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(users, operationClaims),
                signingCredentials: signingCredentials

                );
>>>>>>> d62e57d (API Authorize)
            return jwt;
        }
<<<<<<< HEAD

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaim)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            };

            claims.AddRange(operationClaim.Select(c => new Claim(ClaimTypes.Role, c.Name)));

=======
        private IEnumerable<Claim> SetClaims(Users users, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(users.Id.ToString());
            claims.AddEmail(users.Email);
            claims.AddName($"{users.FirstName} {users.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
>>>>>>> d62e57d (API Authorize)
            return claims;
        }
        
    }


}

<<<<<<< HEAD
=======
    
>>>>>>> d62e57d (API Authorize)
