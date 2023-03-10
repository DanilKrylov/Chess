using Chess.Data.Models;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Interfaces
{
    internal interface IMoveValidator
    {
        bool MoveIsValid(IEnumerable<PieceDto> piecesBeforeMove, PieceDto piece, PiecePositionDto to);
    }
}
