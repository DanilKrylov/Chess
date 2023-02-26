using Chess.Data.Models;
using GamesManagement.DtoModels;
using GamesManagement.Interfaces;
using GamesManagement.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesManagement.Services
{
    internal class GameSearcherService : IGameSearcherService
    {
        private readonly List<PlayerInGameSearchDto> _playersInGamesSearch = new();
        private readonly GameSearchConfigure _searchConfigure;
        private readonly Semaphore _semaphore = new Semaphore(1, 1);

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

        public bool TryRemovePlayerFromSearch(string email)
        {
            _semaphore.WaitOne();
            var player = _playersInGamesSearch.FirstOrDefault(player => player.Email == email);

            if(player is not null)
            {
                _playersInGamesSearch.Remove(player);
            }

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

                    return playersRatingDifference <= totalMaxRatingDifference;
                });

            var blackPlayerPlayer = matchedPlayers.FirstOrDefault();

            if(blackPlayerPlayer == null)
            {
                _semaphore.Release();
                return new PlayersMatch(false);
            }

            _semaphore.Release();
            TryRemovePlayerFromSearch(email);
            TryRemovePlayerFromSearch(blackPlayerPlayer.Email);
            return new PlayersMatch(true, email, blackPlayerPlayer.Email);
        }
    }
}
