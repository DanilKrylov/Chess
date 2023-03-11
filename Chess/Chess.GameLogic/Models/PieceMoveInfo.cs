namespace Chess.GameLogic.Models
{
    public record PieceMoveInfo(Guid GameId, PiecePositionDto From, PiecePositionDto To);
}
