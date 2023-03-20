using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    internal interface IAvailableCagesDetector
    {
        List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PiecePositionDto position);
    }
}
