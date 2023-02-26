using Chess.GameLogic.DtoModels;
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
            return to.HorizontalPosition >= 1 && to.VerticalPosition >= 1 &&
                   to.HorizontalPosition <= 8 && to.VerticalPosition <= 8;
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
