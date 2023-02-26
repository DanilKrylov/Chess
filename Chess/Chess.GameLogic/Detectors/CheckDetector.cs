using Chess.Data.Enums;
using Chess.GameLogic.DtoModels;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Detectors
{
    internal class CheckDetector : ICheckDetector
    {
        private readonly IAvailableCagesDetector _availableCagesDetector;

        public CheckDetector(IAvailableCagesDetector availableCagesDetector)
        {
            _availableCagesDetector = availableCagesDetector;
        }

        public bool IsCheckInPosition(IEnumerable<PieceDto> pieces, Color checkToColor)
        {
            var king = pieces.First(piece => piece.Name == PieceName.King && piece.Color == checkToColor);

            foreach (var piece in pieces.Where(piece => piece.Color == checkToColor.GetOpposite()))
            {
                var availableCages = _availableCagesDetector
                    .GetCagesIndetectingChecks(pieces, piece.Position);

                if (KingInEnemyAvailableCages(availableCages, king))
                    return true;
            }

            return false;
        }
        private bool KingInEnemyAvailableCages(List<PiecePositionDto> cages, PieceDto king)
        {
            return cages.Any(cage => cage == king.Position);
        }
    }
}
