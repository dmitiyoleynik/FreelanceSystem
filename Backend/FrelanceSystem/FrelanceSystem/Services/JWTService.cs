using FrelanceSystem.SecurityKeys;
using FrelanceSystem.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FrelanceSystem.Services
{
    public class JWTService : IJWTService
    {
        private readonly int _tokenExpiration = 20;
        private readonly IJwtSigningEncodingKey _signingEncodingKey;

        public JWTService(IJwtSigningEncodingKey signingEncodingKey)
        {
            _signingEncodingKey = signingEncodingKey;
        }

        public string CreateToken(string userId)
        {
            var claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId)
                };

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "FreelanceSystem server",
                audience: "FreelanceSystem client",
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
