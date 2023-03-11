using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Interfaces
{
    internal interface IMoveInAvailableCagesValidator
    {
        bool IsMoveInAvailableCages(IEnumerable<PieceDto> piecesBeforeMove, PiecePositionDto from, PiecePositionDto to);
    }
}
