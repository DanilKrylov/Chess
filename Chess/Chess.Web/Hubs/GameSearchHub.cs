using GamesManagement.DtoModels;
using GamesManagement.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Chess.Web.Hubs
{
    public class GameSearchHub : Hub
    {
        private readonly IGameSearcherService _gameSearcherService;
        public GameSearchHub(IGameSearcherService gameSearcherService) 
        { 
            _gameSearcherService = gameSearcherService;
        }

        public async Task StartSearch()
        {
            var connectionId = Context.ConnectionId;
            await Clients.Caller.SendAsync("Log", new { message = "started" });
            var userEmail = Context.User.Identity.Name;
            if (userEmail is null)
            {
                return;
            }

            var match = _gameSearcherService.TryGetMatch(userEmail, 1000);

            if(!match.IsMathced)
            {
                _gameSearcherService.TryAddPlayerToSearch(userEmail, 1000);
                await Groups.AddToGroupAsync(Context.ConnectionId, userEmail);
                return;
            }

            //await Groups.RemoveFromGroupAsync(Context.ConnectionId, "searchGame");
            //await Groups.RemoveFromGroupAsync(Clients.Group(match.BlackPlayerEmail).)
        }

        public async Task FinishSearch()
        {
            var userEmail = Context.User.Identity.Name;
            if (userEmail is null)
            {
                return;
            }

            _gameSearcherService.TryRemovePlayerFromSearch(userEmail);
            await Groups.AddToGroupAsync(userEmail, "searchGame");
        }
    }
}
