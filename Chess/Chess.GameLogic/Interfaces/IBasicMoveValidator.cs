using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Interfaces
{
    internal interface IBasicMoveValidator
    {
        bool IsMoveValidOnEmptyBoard(IEnumerable<PieceDto> pieces, PiecePositionDto from, PiecePositionDto to);
    }
}
