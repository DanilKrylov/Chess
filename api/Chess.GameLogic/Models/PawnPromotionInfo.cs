using Chess.Data.Enums;
namespace Chess.GameLogic.Models
{
    public record PawnPromotionInfo(Guid GameId, PiecePositionDto From, PiecePositionDto To, PieceName PromotionToPiece);
}
