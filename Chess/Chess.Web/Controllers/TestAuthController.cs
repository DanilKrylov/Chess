using Chess.Web.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chess.Web.Controllers
{
    [ApiController]
    [Route("/api/authinfo")]
    [Authorize]
    public class TestAuthController : Controller
    {
        private readonly IHubContext<GameSearchHub> _gameSearchHubContext;
        public TestAuthController(IHubContext<GameSearchHub> gameSearchHubContext)
        {
            _gameSearchHubContext = gameSearchHubContext;
        }


        [HttpGet("get")]
        public IActionResult GetAuthInfo()
        {
            return new JsonResult(User.Identity.Name);
        }
    }
}
