using Chess.Data.Enums;
using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Interfaces
{
    public interface ICheckMateDetector
    {
        bool IsCheckMateInPos(List<PieceDto> pieces, Color checkMateToColor);
    }
}
