using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Interfaces
{
    public interface IPieceMoverService
    {
        bool TryMovePiece(PieceMoveInfo pieceMoveInfo, string playerEmail, out GameDto gameAfterMove);

        bool TryCastl(CastlingInfo castlingInfo, string playerEmail, out GameDto gameAfterMove);

        bool TryPromotePawn(PawnPromotionInfo pawnPromotionInfo, string playerEmail, out GameDto gameAfterMove);
    }
}
