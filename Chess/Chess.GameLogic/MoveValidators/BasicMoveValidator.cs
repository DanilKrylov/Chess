using Chess.GameLogic.Extensions;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.MoveValidators
{
    internal class BasicMoveValidator : IBasicMoveValidator
    {
        public bool IsMoveValidOnEmptyBoard(IEnumerable<PieceDto> pieces, PiecePositionDto from, PiecePositionDto to)
        {
            return IsMoveOnBoard(to) && MoveIsNotOnSpot(from, to) && IsPieceOnStartPosition(pieces, from);
        }

        private bool IsMoveOnBoard(PiecePositionDto to)
        {
            return to.PosX >= 1 && to.PosY >= 1 &&
                   to.PosX <= 8 && to.PosY <= 8;
        }

        private bool MoveIsNotOnSpot(PiecePositionDto from, PiecePositionDto to)
        {
            return from != to;
        }

        private bool IsPieceOnStartPosition(IEnumerable<PieceDto> pieces, PiecePositionDto from)
        {
            return pieces.PieceExists(from);
        }
    }
}
