using Chess.Data.Enums;
using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.MoveValidators
{
    internal class BasicMoveValidator : IBasicMoveValidator
    {
        public bool IsMoveValidOnEmptyBoard(GameDto game, PiecePositionDto from, PiecePositionDto to, string playerEmail)
        {
            return PlayerCanDoMove(game, playerEmail) && IsMoveAvailablePiece(game, from, playerEmail) && 
                   IsMoveOnBoard(to) && MoveIsNotOnSpot(from, to);
        }

        private bool IsMoveOnBoard(PiecePositionDto to)
        {
            return to.PosX >= 1 && to.PosY >= 1 &&
                   to.PosX <= 8 && to.PosY <= 8;
        }

        private bool IsMoveAvailablePiece(GameDto game, PiecePositionDto from, string playerEmail)
        {
            var piece = game.Pieces.GetPiece(from);

            if(piece == null)
                return false;

            return playerEmail == game.WhitePlayerEmail && piece.Color == Color.White ||
                   playerEmail == game.BlackPlayerEmail && piece.Color == Color.Black;
        }

        private bool MoveIsNotOnSpot(PiecePositionDto from, PiecePositionDto to)
        {
            return from != to;
        }

        private bool PlayerCanDoMove(GameDto game, string playerEmail)
        {
            return game.MoveTurn == Color.White && game.WhitePlayerEmail == playerEmail ||
                   game.MoveTurn == Color.Black && game.BlackPlayerEmail == playerEmail;
        }
    }
}
