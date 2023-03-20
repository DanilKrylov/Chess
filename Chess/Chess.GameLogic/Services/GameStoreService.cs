using Chess.Data.Interfaces;
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

        public async Task<GameDto> GetGameAsync(Guid gameId)
        {
            return GameMapper.MapToGameDto(await _gameRepository.GetGameAsync(gameId));
        }
    }
}
