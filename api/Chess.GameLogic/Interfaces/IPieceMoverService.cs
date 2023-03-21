using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    public interface IPieceMoverService
    {
        bool TryMovePiece(PieceMoveInfo pieceMoveInfo, string playerEmail, out GameDto gameAfterMove);

        bool TryCastl(CastlingInfo castlingInfo, string playerEmail, out GameDto gameAfterMove);

        bool TryPromotePawn(PawnPromotionInfo pawnPromotionInfo, string playerEmail, out GameDto gameAfterMove);
    }
}
