using Chess.Data.Interfaces;
using Chess.Data.Models;
using GamesManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesManagement.Services
{
    internal class GameStoreService : IGameStoreService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGameCreator _gameCreator;

        public GameStoreService(IGameRepository gameRepository, IGameCreator gameCreator)
        {
            _gameRepository = gameRepository;
            _gameCreator = gameCreator;
        }

        public Task<bool> GameExist(Guid gameId)
        {
            return _gameRepository.GameExist(gameId);
        }

        public Task<Game> GetGameAsync(Guid gameId)
        {
            return _gameRepository.GetGameAsync(gameId);
        }

        public async Task<Game> StartNewGameAsync(string whitePlayerEmail, string blackPlayerEmail)
        {
            var game = await _gameCreator.CreateGameAsync(whitePlayerEmail, blackPlayerEmail);

            await _gameRepository.AddGameAsync(game);
            return game;
        }
    }
}
