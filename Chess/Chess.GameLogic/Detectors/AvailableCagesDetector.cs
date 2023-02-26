using Chess.Data.Models;
using Chess.GameLogic.DtoModels;
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
    internal class AvailableCagesDetector : IAvailableCagesDetector
    {
        private readonly IEnumerable<IPieceTypeAvailableCagesDetector> _detectors;

        public AvailableCagesDetector(IEnumerable<IPieceTypeAvailableCagesDetector> detectors)
        {
            _detectors = detectors;
        }

        public List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PiecePositionDto position)
        {
            var piece = pieces.GetPiece(position);
            var detector = _detectors.First(detector => detector.PieceName == piece.Name);

            return detector.GetCagesIndetectingChecks(pieces, position);
        }
    }
}
