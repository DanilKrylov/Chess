using Chess.Data.Enums;
using Chess.Data.Models;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Interfaces
{
    internal interface IPieceTypeAvailableCagesDetector
    {
        PieceName PieceName { get; }

        List<PiecePositionDto> GetCagesIndetectingChecks(IEnumerable<PieceDto> pieces, PiecePositionDto position);
    }
}
