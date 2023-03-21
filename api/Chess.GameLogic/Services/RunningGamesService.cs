using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;
using System.Collections.Concurrent;

namespace Chess.GameLogic.Services
{
    internal class RunningGameManager : IRunningGamesService
    {
        private readonly ConcurrentDictionary<Guid, GameDto> _games = new();
        private readonly Semaphore _semaphore = new Semaphore(1, 1);

        public GameDto? GetRunningGame(Guid gameId)
        {
            return _games.GetValueOrDefault(gameId);
        }

        public bool TryAddRunningGame(GameDto game)
        {
            _semaphore.WaitOne();
            var gameExists = GameExist(game.GameId);

            if (!gameExists)
            {
                _games[game.GameId] = game;
            }

            _semaphore.Release();
            return !gameExists;
        }

        public bool TryRemoveRunningGame(Guid gameId)
        {
            _semaphore.WaitOne();
            var gameExists = GameExist(gameId);

            if (gameExists)
            {
                _games.Remove(gameId, out var _);
            }

            _semaphore.Release();
            return gameExists;
        }

        public bool TryUpdateRunningGame(Guid gameId, GameDto game)
        {
            _semaphore.WaitOne();
            var gameExists = GameExist(gameId);

            if (gameExists && gameId == game.GameId)
            {
                _games[gameId] = game;
            }

            _semaphore.Release();
            return gameExists;
        }

        private bool GameExist(Guid gameId)
        {
            return _games.Keys.Contains(gameId);
        }
    }
}
