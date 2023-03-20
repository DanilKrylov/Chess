using Chess.Data.Enums;
using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Detectors
{
    internal class BishopAvailableCagesDetector : IPieceTypeAvailableCagesDetector
    {
        private readonly AvailableCagesHelper _availableCagesHelper;
        public PieceName PieceName => PieceName.Bishop;

        public BishopAvailableCagesDetector(AvailableCagesHelper availableCagesHelper)
        {
            _availableCagesHelper = availableCagesHelper;
        }

        public List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PieceDto piece)
        {
            var availableCages = new List<PiecePositionDto>();

            availableCages.AddRange(GetCagesMovingWith(pieces, piece, 1, 1));
            availableCages.AddRange(GetCagesMovingWith(pieces, piece, 1, -1));
            availableCages.AddRange(GetCagesMovingWith(pieces, piece, -1, 1));
            availableCages.AddRange(GetCagesMovingWith(pieces, piece, -1, -1));

            return availableCages;
        }

        private List<PiecePositionDto> GetCagesMovingWith(IEnumerable<PieceDto> pieces, PieceDto bishop, int vertPosDiffKoef, int horPosDiffKoef) =>
            _availableCagesHelper.GetAvailableCagesMovingWith(pieces, bishop, vertPosDiffKoef, horPosDiffKoef);
    }
}