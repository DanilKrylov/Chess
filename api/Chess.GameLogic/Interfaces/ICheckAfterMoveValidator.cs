using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    internal interface ICheckAfterMoveValidator
    {
        bool IsCheckAfterMove(IEnumerable<PieceDto> piecesBeforeMove, PieceDto piece, PiecePositionDto to);
    }
}
