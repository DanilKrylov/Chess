using Chess.Data.Enums;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    internal interface IPieceTypeMoveValidator
    {
        PieceName PieceName { get; }
        bool ValidateMove(List<PieceDto> piecesBeforeMove, PieceDto piece, PiecePositionDto to);
    }
}
