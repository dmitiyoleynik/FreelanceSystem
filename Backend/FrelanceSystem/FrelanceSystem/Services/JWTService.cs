using FrelanceSystem.SecurityKeys;
using FrelanceSystem.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FrelanceSystem.Utils;

namespace FrelanceSystem.Services
{
    public class JWTService : IJWTService
    {
        private readonly int _tokenExpiration;
        private readonly IJwtSigningEncodingKey _signingEncodingKey;

        public JWTService(IJwtSigningEncodingKey signingEncodingKey,
            IConfiguration configuration)
        {
            _signingEncodingKey = signingEncodingKey;
            _tokenExpiration = configuration.GetValue<int>("TokenExpiration");
        }

        public string CreateToken(string userId)
        {
            var claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId)
                };

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: Constants.JWTissuer,
                audience: Constants.JTWaudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_tokenExpiration),
                signingCredentials: new SigningCredentials(
                        _signingEncodingKey.GetKey(),
                        _signingEncodingKey.SigningAlgorithm)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
