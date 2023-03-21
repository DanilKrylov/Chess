using Chess.GameLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Web.Controllers
{
    [ApiController]
    [Route("api/gamestore")]
    public class GameController : ControllerBase
    {
        private readonly IGameStoreService _gameStoreService;

        public GameController(IGameStoreService gameStoreService)
        {
            _gameStoreService = gameStoreService;
        }

        [HttpGet("gameInfo/{gameId}")]
        public async Task<IActionResult> Get(Guid gameId)
        {
            return Ok(await _gameStoreService.GetGameAsync(gameId));
        }
    }
}
