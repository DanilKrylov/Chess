using Chess.Data.Models;
using Chess.GameLogic.Interfaces;
using Chess.GamesManagement.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Chess.Web.Hubs
{
    [Authorize]
    public class GameSearchHub : Hub
    {
        private readonly IGameSearcherService _gameSearcherService;
        private readonly UserManager<Player> _userManager;
        private readonly IGameCreationService _gameCreationService;

        public GameSearchHub(IGameSearcherService searcherService, UserManager<Player> userManager, IGameCreationService creationService)
        {
            _gameSearcherService = searcherService;
            _userManager = userManager;
            _gameCreationService = creationService;
        }

        public async Task StartSearch()
        {
            var userEmail = Context.User.Identity.Name;

            var player = await _userManager.FindByEmailAsync(userEmail);

            if (player is null)
                return;

            await Groups.AddToGroupAsync(Context.ConnectionId, userEmail);
            var match = _gameSearcherService.TryGetMatch(userEmail, player.Rating);

            if (!match.IsMathced)
            {
                _gameSearcherService.TryAddPlayerToSearch(userEmail, player.Rating);
                return;
            }

            var game = await _gameCreationService.StartNewGameAsync(match.WhitePlayerEmail, match.BlackPlayerEmail);

            await Clients.Group(match.WhitePlayerEmail).SendAsync("searchFinish", game);
            await Clients.Group(match.BlackPlayerEmail).SendAsync("searchFinish", game);
        }

        public async Task FinishSearch()
        {
            var userEmail = Context.User.Identity.Name;
            if (userEmail is null)
            {
                return;
            }

            _gameSearcherService.TryRemovePlayerFromSearch(userEmail);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userEmail = Context.User.Identity.Name;

            _gameSearcherService.TryRemovePlayerFromSearch(userEmail);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userEmail);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
