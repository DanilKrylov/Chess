using Chess.Data.Interfaces;
using Chess.Data.Models;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Mappers;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
