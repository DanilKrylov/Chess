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
    internal class RookAvailableCagesDetector : IPieceTypeAvailableCagesDetector
    {
        private readonly AvailableCagesHelper _availableCagesHelper;
        public PieceName PieceName => PieceName.Rock;

        public RookAvailableCagesDetector(AvailableCagesHelper availableCagesHelper)
        {
            _availableCagesHelper = availableCagesHelper;
        }

        public List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PiecePositionDto position)
        {
            var availableCages = new List<PiecePositionDto>();
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                availableCages.AddRange(GetCagesMovingTo(pieces, position, direction));
            }

            return availableCages;
        }

        private List<PiecePositionDto> GetCagesMovingTo(IEnumerable<PieceDto> pieces, PiecePositionDto position, Direction direction)
        {
            var checkingRook = pieces.GetPiece(position);

            SetPosDiffKoefs(direction, out int vertPosDiffKoef, out int horPosDiffKoef);
            return _availableCagesHelper.GetAvailableCagesMovingWith(pieces, checkingRook, vertPosDiffKoef, horPosDiffKoef);
        }

        private void SetPosDiffKoefs(Direction direction, out int vertPosDiffKoef, out int horPosDiffKoef)
        {
            vertPosDiffKoef = 0;
            horPosDiffKoef = 0;

            switch (direction)
            {
                case Direction.Up:
                    vertPosDiffKoef = 1;
                    break;
                case Direction.Down:
                    vertPosDiffKoef = -1;
                    break;
                case Direction.Left:
                    horPosDiffKoef = -1;
                    break;
                case Direction.Right:
                    horPosDiffKoef = 1;
                    break;
            }
        }

        private enum Direction
        {
            Left,
            Right,
            Up,
            Down,
        }
    }
}
