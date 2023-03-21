using Chess.Data.Enums;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    internal interface ICheckDetector
    {
        bool IsCheckInPosition(IEnumerable<PieceDto> pieces, Color checkToColor);
    }
}
