using Chess.Data.Interfaces;
using Chess.Data.Models;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Mappers;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Services
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

        public async Task<GameDto> GetGameAsync(Guid gameId)
        {
            return GameMapper.MapToGameDto(await _gameRepository.GetGameAsync(gameId));
        }
    }
}
