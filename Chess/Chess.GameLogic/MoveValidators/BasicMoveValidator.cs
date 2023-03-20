using Chess.Data.Enums;
using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.MoveValidators
{
    internal class BasicMoveValidator : IBasicMoveValidator
    {
        public bool IsMoveValidOnEmptyBoard(GameDto game, PieceDto piece, PiecePositionDto to, string playerEmail)
        {
            return piece is not null && PlayerCanDoMove(game, playerEmail) && 
                   IsMoveAvailablePiece(game, piece, playerEmail) && 
                   IsMoveOnBoard(to) && MoveIsNotOnSpot(piece.Position, to);
        }

        public bool IsCastlingValidOnEmptyBoard(GameDto game, string playerEmail)
        {
            return PlayerCanDoMove(game, playerEmail);
        }

        private bool IsMoveOnBoard(PiecePositionDto to)
        {
            return to.PosX >= 1 && to.PosY >= 1 &&
                   to.PosX <= 8 && to.PosY <= 8;
        }

        private bool IsMoveAvailablePiece(GameDto game, PieceDto piece, string playerEmail)
        {
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
