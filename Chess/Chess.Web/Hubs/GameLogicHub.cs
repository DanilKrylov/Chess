using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Chess.Web.Hubs
{
    [Authorize]
    public class GameLogicHub : Hub
    {
        private readonly IGameLogicService _gameLogicService;
        private readonly IRunningGamesService _runningGamesService;
        private readonly ICheckMateDetector _checkMateDetector;

        public GameLogicHub(IGameLogicService gameLogicService, IRunningGamesService runningGamesService, ICheckMateDetector checkMateDetector)
        {
            _gameLogicService = gameLogicService;
            _runningGamesService = runningGamesService;
            _checkMateDetector = checkMateDetector;
        }

        public async Task MovePiece(PieceMoveInfo pieceMoveInfo)
        {
            var playerEmail = Context.User.Identity.Name;
            if (!_gameLogicService.TryMovePiece(pieceMoveInfo, playerEmail, out var game))
                throw new ArgumentException();

            await Clients.Group(pieceMoveInfo.GameId.ToString()).SendAsync("movePiece", game);
        }

        public async Task DetectCheckMate(Guid gameId)
        {
            var result = await _gameLogicService.TryEndGameByCheckMateAsync(gameId);
            if (result.IsEnded)
                await Clients.Group(gameId.ToString()).SendAsync("finishGame");
        }

        public async Task JoinToGame(Guid gameId)
        {
            var game = _runningGamesService.GetRunningGame(gameId);
            if (game is null)
                throw new ArgumentException("game is not defined");

            await Groups.AddToGroupAsync(Context.ConnectionId, gameId.ToString());
            await Clients.Caller.SendAsync("setGame", game);
        }
    }
}
