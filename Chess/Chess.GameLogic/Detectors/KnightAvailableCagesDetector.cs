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
    internal class KnightAvailableCagesDetector : IPieceTypeAvailableCagesDetector
    {
        private readonly int[] posDifferences = new int[] { -2, -1, 1, 2 };
        public PieceName PieceName => PieceName.Knight;

        public List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PiecePositionDto position)
        {
            var availableCages = new List<PiecePositionDto>();
            var piece = pieces.GetPiece(position);

            foreach (var horDiff in posDifferences)
            {
                foreach (var vertDiff in posDifferences)
                {
                    if (Math.Abs(horDiff) == Math.Abs(vertDiff))
                        continue;

                    var currentPos = 
                        new PiecePositionDto(position.PosY + vertDiff, position.PosX + horDiff);

                    if (pieces.CanBeSetedToPosition(currentPos, piece.Color, out bool _))
                        availableCages.Add(currentPos);
                }
            }
            
            return availableCages;
        }
    }
}
