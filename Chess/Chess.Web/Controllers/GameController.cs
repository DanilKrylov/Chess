using Chess.GamesManagement.Interfaces;
using Chess.Web.ViewModels;
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

        /*[HttpPost("create")]
        public JsonResult Create([FromBody]GamePlayers playersIdes)
        {
            return new JsonResult(_gameStoreService.StartNewGame(playersIdes.WhitePlayerEmail, playersIdes.BlackPlayerEmail));
        }*/
    }
}
