using Chess.Data.Enums;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    internal interface IPieceTypeAvailableCagesDetector
    {
        PieceName PieceName { get; }

        List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PiecePositionDto position);
    }
}
