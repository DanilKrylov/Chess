using Chess.GameLogic.Extensions;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Detectors
{
    internal class AvailableCagesHelper
    {
        public List<PiecePositionDto> GetAvailableCagesMovingWith(IEnumerable<PieceDto> pieces, PieceDto current, int vertPosDiffKoef, int horPosDiffKoef)
        {
            var vertPos = current.Position.PosY + vertPosDiffKoef;
            var horPos = current.Position.PosX + horPosDiffKoef;
            var availableCages = new List<PiecePositionDto>();

            while (true)
            {
                var checkedPos = new PiecePositionDto(vertPos, horPos);
                var canBeSetedToPos = pieces.CanBeSetedToPosition(checkedPos, current.Color, out bool isEnemyOnCage);
                if (canBeSetedToPos)
                    availableCages.Add(checkedPos);

                if (!canBeSetedToPos || isEnemyOnCage)
                    return availableCages;

                vertPos += vertPosDiffKoef;
                horPos += horPosDiffKoef;
            }
        }
    }
}