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

        public GameLogicHub(IGameLogicService gameLogicService, IRunningGamesService runningGamesService)
        {
            _gameLogicService = gameLogicService;
            _runningGamesService = runningGamesService;
        }

        public async Task MovePiece(PieceMoveInfo pieceMoveInfo)
        {
            var playerEmail = Context.User.Identity.Name;
            if (!_gameLogicService.TryMovePiece(pieceMoveInfo, playerEmail, out var pieces))
                return;

            await Clients.Group(pieceMoveInfo.GameId.ToString()).SendAsync("movePiece", pieces);
        }

        public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
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
