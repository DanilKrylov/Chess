using Chess.Web.ViewModels;
using GamesManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Web.Controllers
{
    [ApiController]
    [Route("/gamestore")]
    public class GameController : ControllerBase
    {
        private readonly IGameStoreService _gameStoreService;

        public GameController(IGameStoreService gameStoreService)
        {
            _gameStoreService = gameStoreService;
        }

        [HttpGet("game/{gameId}")]
        public async Task<JsonResult> Get(Guid gameId)
        {
            return new JsonResult(await _gameStoreService.GetGameAsync(gameId));
        }

        [HttpPost("create")]
        public async Task<JsonResult> Create([FromBody]GamePlayers playersIdes)
        {
            return new JsonResult(await _gameStoreService.StartNewGameAsync(playersIdes.WhitePlayerEmail, playersIdes.BlackPlayerEmail));
        }
    }
}
