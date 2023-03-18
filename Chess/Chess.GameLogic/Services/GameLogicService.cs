using Chess.Data.Enums;
using Chess.Data.Interfaces;
using Chess.Data.Models;
using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Services
{
    internal class GameLogicService : IGameLogicService
    {
        private readonly IMoveValidator _moveValidator;
        private readonly IRunningGamesService _runningGamesService;
        private readonly ICheckMateDetector _checkMateDetector;
        private readonly IGameUpdaterService _gameUpdaterService;

        public GameLogicService(IMoveValidator moveValidator, IRunningGamesService runningGamesService, ICheckMateDetector checkMateDetector, IGameUpdaterService gameUpdaterService)
        {
            _moveValidator = moveValidator;
            _runningGamesService = runningGamesService;
            _checkMateDetector = checkMateDetector;
            _gameUpdaterService = gameUpdaterService;
        }

        public async Task<GameResultInfo> TryEndGameByCheckMateAsync(Guid gameId)
        {
            var game = _runningGamesService.GetRunningGame(gameId);
            var result = new GameResultInfo(false);

            if(_checkMateDetector.IsCheckMateInPos(game.Pieces, Color.White))
            {
                result = new GameResultInfo(true, false, game.BlackPlayerEmail);
            }

            if (_checkMateDetector.IsCheckMateInPos(game.Pieces, Color.Black))
            {
                result = new GameResultInfo(true, false, game.WhitePlayerEmail);
            }

            if (result.IsEnded)
                await EndGame(gameId, result);

            return result;
        }

        public bool TryMovePiece(PieceMoveInfo pieceMoveInfo, string playerEmail, out GameDto gameAfterMove)
        {
            gameAfterMove = null;
            var game = _runningGamesService.GetRunningGame(pieceMoveInfo.GameId);
            if (game is null)
                return false;

            var pieces = game.Pieces;
            var piece = pieces.GetPiece(pieceMoveInfo.From);

            if (piece is null || !_moveValidator.MoveIsValid(game, piece, pieceMoveInfo.To, playerEmail))
                return false;

            game.Pieces.MovePiece(piece, pieceMoveInfo.To);
            game.ChangeMoveTurn();
            gameAfterMove = game;
            return true;
        }

        private async Task EndGame(Guid gameId, GameResultInfo result)
        {
            var gameDto = _runningGamesService.GetRunningGame(gameId);
            _runningGamesService.TryRemoveRunningGame(gameId);
            await _gameUpdaterService.UpdateGame(gameId, gameDto, result);
        }
    }
}
