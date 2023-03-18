using Chess.Data.Enums;
using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Detectors
{
    internal class CheckMateDetector : ICheckMateDetector
    {
        private readonly ICheckDetector _checkDetector;
        private readonly IAvailableCagesDetector _availableCagesDetector;

        public CheckMateDetector(ICheckDetector checkDetector, IAvailableCagesDetector availableCagesDetector)
        {
            _checkDetector = checkDetector;
            _availableCagesDetector = availableCagesDetector;
        }

        public bool IsCheckMateInPos(List<PieceDto> pieces, Color checkMateToColor)
        {
            if (!_checkDetector.IsCheckInPosition(pieces, checkMateToColor))
                return false;

            foreach (PieceDto piece in pieces.Where(p => p.Color == checkMateToColor))
            {
                var availableCagesForPiece = _availableCagesDetector.GetCagesIndetectingChecks(pieces, piece.Position);

                foreach(var availableCage in availableCagesForPiece)
                {
                    var piecesAfterMove = pieces.GetPiecesWithMovedPiece(piece.Position, availableCage);
                    if (!_checkDetector.IsCheckInPosition(piecesAfterMove, checkMateToColor))
                        return false;
                }
            }

            return true;
        }
    }
}
