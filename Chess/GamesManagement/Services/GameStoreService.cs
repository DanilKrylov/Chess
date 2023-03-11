using Chess.Data.Interfaces;
using Chess.Data.Models;
using Chess.GamesManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GamesManagement.Services
{
    internal class GameStoreService : IGameStoreService
    {
        private readonly IGameRepository _gameRepository;

        public GameStoreService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Task<bool> GameExist(Guid gameId)
        {
            return _gameRepository.GameExist(gameId);
        }

        public Task<Game> GetGameAsync(Guid gameId)
        {
            return _gameRepository.GetGameAsync(gameId);
        }
    }
}
