using Chess.Data.Models;
using GamesManagement.Interfaces;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Chess.Web.Hubs
{
    public class GameSearchHub : Hub
    {
        private readonly IGameSearcherService _gameSearcherService;
        private readonly UserManager<Player> _userManager;

        public GameSearchHub(IGameSearcherService gameSearcherService, UserManager<Player> userManager) 
        { 
            _gameSearcherService = gameSearcherService;
            _userManager = userManager;
        }

        public async Task StartSearch()
        {
            await Clients.Caller.SendAsync("Log", new { message = "started" });
            var userEmail = Context.User.Identity.Name;
            if (userEmail is null)
            {
                return;
            }

            var player = await _userManager.FindByEmailAsync(userEmail);

            if(player is null)
            {
                return;
            }

            var match = _gameSearcherService.TryGetMatch(userEmail, player.Rating);

            if(!match.IsMathced)
            {
                _gameSearcherService.TryAddPlayerToSearch(userEmail, player.Rating);
                await Groups.AddToGroupAsync(Context.ConnectionId, userEmail);
                return;
            }
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
        }
    }
}
