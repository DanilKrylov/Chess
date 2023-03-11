using Chess.Data.Models;
using Chess.GamesManagement.DtoModels;
using Chess.GamesManagement.Interfaces;
using Chess.GamesManagement.Options;
using Microsoft.Extensions.Options;

namespace Chess.GamesManagement.Services
{
    internal class GameSearcherService : IGameSearcherService
    {
        private readonly List<PlayerInGameSearchDto> _playersInGamesSearch = new();
        private readonly GameSearchConfigure _searchConfigure;
        private readonly Semaphore _semaphore = new(1, 1);

        public GameSearcherService(IOptions<GameSearchConfigure> gameSearchConfigure)
        {
            _searchConfigure = gameSearchConfigure.Value;
        }


        public bool TryAddPlayerToSearch(string email, int rating)
        {
            _semaphore.WaitOne();

            var isPlayerInList = _playersInGamesSearch.Any(player => player.Email == email);
            if (!isPlayerInList)
            {
                _playersInGamesSearch.Add(new PlayerInGameSearchDto(email, rating));
            }

            _semaphore.Release();

            return !isPlayerInList;
        }

        public bool TryRemovePlayerFromSearch(string email) =>
            TryRemovePlayerFromSearch(email, true);

        internal bool TryRemovePlayerFromSearch(string email, bool isUserRequest)
        {
            if(isUserRequest)
                _semaphore.WaitOne();

            var player = _playersInGamesSearch.FirstOrDefault(player => player.Email == email);

            if(player is not null)
            {
                _playersInGamesSearch.Remove(player);
            }

            if (isUserRequest)
                _semaphore.Release();

            return player is not null;
        }

        public PlayersMatch TryGetMatch(string email, int rating)
        {
            _semaphore.WaitOne();
            var matchedPlayers = _playersInGamesSearch
                .Where(player =>
                {
                    var playersRatingDifference = Math.Abs(player.Rating - rating);
                    var ratingTimeIncrasing = _searchConfigure.RatingDifference.IncrasingFor1Seconds * player.SecondsInSearching;
                    var totalMaxRatingDifference = _searchConfigure.RatingDifference.DefaultMax + ratingTimeIncrasing;

                    return playersRatingDifference <= totalMaxRatingDifference && player.Email != email;
                });

            var blackPlayerPlayer = matchedPlayers.FirstOrDefault();

            if(blackPlayerPlayer == null)
            {
                _semaphore.Release();
                return new PlayersMatch(false);
            }

            TryRemovePlayerFromSearch(email, false);
            TryRemovePlayerFromSearch(blackPlayerPlayer.Email, false);
            _semaphore.Release();

            return new PlayersMatch(true, email, blackPlayerPlayer.Email);
        }
    }
}
