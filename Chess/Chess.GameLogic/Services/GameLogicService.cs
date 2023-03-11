using Chess.Data.Enums;
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

        public GameLogicService(IMoveValidator moveValidator, IRunningGamesService runningGamesService)
        {
            _moveValidator = moveValidator;
            _runningGamesService = runningGamesService;
        }

        public bool TryMovePiece(PieceMoveInfo pieceMoveInfo, string playerEmail, out List<PieceDto> piecesAfterMove)
        {
            piecesAfterMove = null;
            var game = _runningGamesService.GetRunningGame(pieceMoveInfo.GameId);
            if (game is null || !PlayerCanDoMove(game, playerEmail))
                return false;

            var pieces = game.Pieces;
            var piece = pieces.GetPiece(pieceMoveInfo.From);

            if (piece is null || !_moveValidator.MoveIsValid(pieces, piece, pieceMoveInfo.To))
                return false;

            game.Pieces.MovePiece(piece, pieceMoveInfo.To);
            game.ChangeMoveTurn();
            piecesAfterMove = game.Pieces;
            return true;
        }

        private bool PlayerCanDoMove(GameDto game, string playerEmail)
        {
            return game.MoveTurn == Color.White && game.WhitePlayerEmail == playerEmail ||
                   game.MoveTurn == Color.Black && game.BlackPlayerEmail == playerEmail;
        }
    }
}
