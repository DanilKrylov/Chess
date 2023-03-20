using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    internal interface IBasicMoveValidator
    {
        bool IsMoveValidOnEmptyBoard(GameDto game, PieceDto piece, PiecePositionDto to, string playerEmail);

        bool IsCastlingValidOnEmptyBoard(GameDto game, string playerEmail);
    }
}
