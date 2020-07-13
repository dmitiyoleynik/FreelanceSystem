using BussinessLayer.Utils;
using FrelanceSystem.Services;
using FrelanceSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FrelanceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJWTService _jwtService;
        private readonly IAccountUtils _accountUtils;

        public AuthenticationController(IJWTService JWTService,
            IAccountUtils accountUtils)
        {
            _accountUtils = accountUtils;
            _jwtService = JWTService;
        }

        [HttpPost]
        public ActionResult<string> Post(UserAuthData user)
        {
            var id = _accountUtils.Login(user.Login, user.Password);

            if (id == null)
            {
                return NotFound();
            }
            else
            {
                string token = _jwtService.CreateToken(id);
                return new JsonResult(new { token });
            }
        }
    }
}
