using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.MoveValidators
{
    internal class MoveInAvailableCagesValidator : IMoveInAvailableCagesValidator
    {
        private readonly IAvailableCagesDetector _availableCagesDetector;
        public MoveInAvailableCagesValidator(IAvailableCagesDetector availableCagesDetector)
        {
            _availableCagesDetector = availableCagesDetector;
        }

        public bool IsMoveInAvailableCages(IEnumerable<PieceDto> piecesBeforeMove, PieceDto piece, PiecePositionDto newPosition)
        {
            var availableCages = _availableCagesDetector.GetCagesIndetectingChecks(piecesBeforeMove, piece);

            return availableCages.Any(cage => cage == newPosition);
        }
    }
}
