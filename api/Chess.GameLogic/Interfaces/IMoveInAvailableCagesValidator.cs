using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    internal interface IMoveInAvailableCagesValidator
    {
        bool IsMoveInAvailableCages(IEnumerable<PieceDto> piecesBeforeMove, PieceDto piece, PiecePositionDto to);
    }
}
