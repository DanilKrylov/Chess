using Chess.Data.Interfaces;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Mappers;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Services
{
    internal class GameUpdaterService : IGameUpdaterService
    {
        private readonly IGameRepository _gameRepository;

        public GameUpdaterService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task UpdateGame(Guid gameId, GameDto gameDto, GameResultInfo gameResult)
        {
            var game = await _gameRepository.GetGameAsync(gameId);
            game.Pieces = PieceMapper.MapToPieces(gameDto.Pieces, gameId).ToList();
            game.WinnerPlayerEmail = gameResult.WinnerPlayerEmail;
            game.IsEnded = gameResult.IsEnded;
            game.IsDraw = gameResult.IsDraw;

            await _gameRepository.UpdateGameAsync(game, game.GameId);
        }
    }
}
