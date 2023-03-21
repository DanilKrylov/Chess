using Chess.Authorize.DtoModels;
using Chess.Authorize.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [Authorize]
        [HttpGet("checkAuth")]
        public IActionResult Check()
        {
            return Ok();
        }
    }
}
