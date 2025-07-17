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
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {

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


        public AccessToken CreateToken(User users, List<OperationClaim> operationClaims)
        {
            var securtyKey = SecurityKeyHelper.CreateSecurtyKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securtyKey);
            var jwt = CreateJwtSecurtyToken(_tokenOptions, users, signingCredentials, operationClaims);
            var jwtSecurtyTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurtyTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration,
            };


        }

        public JwtSecurityToken CreateJwtSecurtyToken(TokenOptions tokenOptions, User users,
                                  SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(users, operationClaims),
                signingCredentials: signingCredentials

                );
            return jwt;


        }
        private IEnumerable<Claim> SetClaims(User users, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(users.Id.ToString());
            claims.AddEmail(users.Email);
            claims.AddName($"{users.FirstName} {users.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }
        
    }


}

    
