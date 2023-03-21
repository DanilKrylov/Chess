using Chess.Data.Enums;
using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Detectors
{
    internal class RookAvailableCagesDetector : IPieceTypeAvailableCagesDetector
    {
        private readonly AvailableCagesHelper _availableCagesHelper;
        public PieceName PieceName => PieceName.Rook;

        public RookAvailableCagesDetector(AvailableCagesHelper availableCagesHelper)
        {
            _availableCagesHelper = availableCagesHelper;
        }

        public List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PieceDto piece)
        {
            var availableCages = new List<PiecePositionDto>();

            availableCages.AddRange(GetCagesMovingTo(pieces, piece, 0, 1));
            availableCages.AddRange(GetCagesMovingTo(pieces, piece, 0, -1));
            availableCages.AddRange(GetCagesMovingTo(pieces, piece, -1, 0));
            availableCages.AddRange(GetCagesMovingTo(pieces, piece, -1, 0));

            return availableCages;
        }

        private List<PiecePositionDto> GetCagesMovingTo(IEnumerable<PieceDto> pieces, PieceDto rook, int vertPosDiffKoef, int horPosDiffKoef) =>
            _availableCagesHelper.GetAvailableCagesMovingWith(pieces, rook, vertPosDiffKoef, horPosDiffKoef);
    }
}
