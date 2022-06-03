using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Api.Controllers
{
    [Route("account")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AuthenticationController(IUserService userService, 
        ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Authenticate([FromBody] User model)
        {
            var user = _userService.GetUser(model);

            if (user == null)
                return NotFound(new { message = "Invalid Username or Password!" });

            var token = _tokenService.GenerateToken(user);

            //hide the password
            user.Password = "";

            return new
            {
                user,
                token
            };
        }
    }
}
