using BussinessLayer.Validators;
using FrelanceSystem.SecurityKeys;
using FrelanceSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FrelanceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly int _tockenExpiration = 20;
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<string> Post(UserAuthData user,
        [FromServices] IJwtSigningEncodingKey signingEncodingKey,
        [FromServices] IUsersValidator usersValidator)
        {
            if (!usersValidator.IsExists(user.Login,user.Password))
            {
                return NotFound();
            }

            var claims = new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Login)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "FreelanceSystem server",
                audience: "FreelanceSystem client",
                claims: claims,
                expires: DateTime.Now.AddMinutes(_tockenExpiration),
                signingCredentials: new SigningCredentials(
                        signingEncodingKey.GetKey(),
                        signingEncodingKey.SigningAlgorithm)
            );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return new JsonResult(new { token });
        }
    }
}
