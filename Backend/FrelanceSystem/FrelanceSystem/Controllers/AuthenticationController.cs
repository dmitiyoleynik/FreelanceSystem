using BussinessLayer.Validators;
using FrelanceSystem.Services;
using FrelanceSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrelanceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsersValidator _usersValidator;
        private readonly IJWTService _JWTService;

        public AuthenticationController(IUsersValidator usersValidator,
            IJWTService JWTService)
        {
            _usersValidator = usersValidator;
            _JWTService = JWTService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<string> Post(UserAuthData user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_usersValidator.IsExists(user.Login, user.Password))
            {
                return NotFound();
            }

            string token = _JWTService.CreateTocken(user);

            return new JsonResult(new { token });
        }
    }
}
