using Chess.Data.Enums;
using Chess.Data.Models;
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

        public List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PiecePositionDto position)
        {
            var availableCages = new List<PiecePositionDto>();

            availableCages.AddRange(_rookCagesDetector.GetCagesIndetectingChecks(pieces, position));
            availableCages.AddRange(_bishopCagesDetector.GetCagesIndetectingChecks(pieces, position));

            return availableCages;
        }
    }
}
