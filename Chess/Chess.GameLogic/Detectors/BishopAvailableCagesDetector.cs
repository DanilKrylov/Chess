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
    internal class BishopAvailableCagesDetector : IPieceTypeAvailableCagesDetector
    {
        private readonly AvailableCagesHelper _availableCagesHelper;
        public PieceName PieceName => PieceName.Bishop;

        public BishopAvailableCagesDetector(AvailableCagesHelper availableCagesHelper)
        {
            _availableCagesHelper = availableCagesHelper;
        }

        public List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PiecePositionDto position)
        {
            var availableCages = new List<PiecePositionDto>();
            availableCages.AddRange(GetCagesMovingTo(pieces, position, VerticalDirection.Up, HorizontalDirection.Left));
            availableCages.AddRange(GetCagesMovingTo(pieces, position, VerticalDirection.Up, HorizontalDirection.Right));
            availableCages.AddRange(GetCagesMovingTo(pieces, position, VerticalDirection.Down, HorizontalDirection.Left));
            availableCages.AddRange(GetCagesMovingTo(pieces, position, VerticalDirection.Down, HorizontalDirection.Right));

            return availableCages;
        }

        private List<PiecePositionDto> GetCagesMovingTo(IEnumerable<PieceDto> pieces, PiecePositionDto position, VerticalDirection vertDirection, HorizontalDirection horDirection)
        {
            var checkingBishop = pieces.GetPiece(position);
            var vertPosDiffKoef = vertDirection == VerticalDirection.Up ? 1 : -1;
            var horPosDiffKoef = horDirection == HorizontalDirection.Right ? 1 : -1;

            return _availableCagesHelper.GetAvailableCagesMovingWith(pieces, checkingBishop, vertPosDiffKoef, horPosDiffKoef);
        }

        private enum VerticalDirection
        {
            Up,
            Down,
        }

        private enum HorizontalDirection
        {
            Left,
            Right,
        }
    }
}