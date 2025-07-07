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

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurtyToken(TokenOptions tokenOptions, User user,
                                                      SigningCredentials signingCredentials,
                                                      List<OperationClaim> operationClaim)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                notBefore: DateTime.Now,
                expires: _accessTokenExpiration,
                claims: SetClaims(user, operationClaim),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaim)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            };

            claims.AddRange(operationClaim.Select(c => new Claim(ClaimTypes.Role, c.Name)));

            return claims;
        }
    }
}

