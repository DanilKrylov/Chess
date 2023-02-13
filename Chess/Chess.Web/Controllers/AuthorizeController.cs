using Chess.Authorize.DtoModels;
using Chess.Authorize.Interfaces;
using Chess.Data.Models;
using Chess.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Chess.Web.Controllers
{
    [Route("api/authorize")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizer _authorizer;

        public AuthorizeController(IAuthorizer authorizer)
        {
            _authorizer = authorizer;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto loginModel)
        {
            return new JsonResult(await _authorizer.TryLoginAsync(loginModel));
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto registerModel)
        {
            return new JsonResult(await _authorizer.TryRegisterAsync(registerModel));
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await _authorizer.LogoutAsync();
            return Ok();
        }
    }
}
