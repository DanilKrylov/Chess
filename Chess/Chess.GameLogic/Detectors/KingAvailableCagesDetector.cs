using Chess.Data.Enums;
using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Detectors
{
    internal class KingAvailableCagesDetector : IPieceTypeAvailableCagesDetector
    {
        public PieceName PieceName => PieceName.King;

        public List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PiecePositionDto position)
        {
            var availableCages = new List<PiecePositionDto>();
            var (vertPos, horPos) = position;
            var king = pieces.GetPiece(position);

            for (var vertDiff = -1; vertDiff <= 1; vertDiff++)
            {
                for (var horDiff = -1; horDiff <= 1; horDiff++)
                {
                    if (vertDiff == 0 && horDiff == 0)
                        continue;

                    var currentVertPos = vertPos + vertDiff;
                    var currentHorPos = horPos + horDiff;

                    if (currentHorPos > 8 || currentHorPos < 1 || currentVertPos > 8 || currentVertPos < 1)
                        continue;

                    var currentPosition = new PiecePositionDto(currentVertPos, currentHorPos);
                    var pieceOnCage = pieces.GetPiece(currentPosition);
                    if (pieceOnCage is null || pieceOnCage.Color != king.Color)
                        availableCages.Add(currentPosition);
                }
            }

            return availableCages;
        }
    }
}
