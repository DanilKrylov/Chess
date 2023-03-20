using Chess.Data.Enums;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Detectors
{
    internal class QueenAvailableCagesDetector : IPieceTypeAvailableCagesDetector
    {
        private readonly RookAvailableCagesDetector _rookCagesDetector;
        private readonly BishopAvailableCagesDetector _bishopCagesDetector;

        public QueenAvailableCagesDetector(RookAvailableCagesDetector rookDetector, BishopAvailableCagesDetector bishopDetector)
        {
            _bishopCagesDetector = bishopDetector;
            _rookCagesDetector = rookDetector;
        }

        public PieceName PieceName => PieceName.Queen;

        public List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PieceDto piece)
        {
            var availableCages = new List<PiecePositionDto>();

            availableCages.AddRange(_rookCagesDetector.GetCagesIndetectingChecks(pieces, piece));
            availableCages.AddRange(_bishopCagesDetector.GetCagesIndetectingChecks(pieces, piece));

            return availableCages;
        }
    }
}
