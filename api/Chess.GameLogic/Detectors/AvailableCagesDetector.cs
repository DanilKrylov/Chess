using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Detectors
{
    internal class AvailableCagesDetector : IAvailableCagesDetector
    {
        private readonly IEnumerable<IPieceTypeAvailableCagesDetector> _detectors;

        public AvailableCagesDetector(IEnumerable<IPieceTypeAvailableCagesDetector> detectors)
        {
            _detectors = detectors;
        }

        public List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PieceDto piece)
        {
            var detector = _detectors.First(detector => detector.PieceName == piece.Name);

            return detector.GetCagesIndetectingChecks(pieces, piece);
        }
    }
}
