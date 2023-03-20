using Chess.Data.Enums;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    public interface ICheckMateDetector
    {
        bool IsCheckMateInPos(List<PieceDto> pieces, Color checkMateToColor);
    }
}
