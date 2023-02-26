using Chess.GameLogic.DtoModels;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Interfaces
{
    internal interface ICheckAfterMoveValidator
    {
        bool IsCheckAfterMove(IEnumerable<PieceDto> piecesBeforeMove, PieceDto piece, PiecePositionDto to);
    }
}
