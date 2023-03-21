using Chess.Data.Enums;

namespace Chess.GameLogic.Models
{
    public record CastlingInfo(Guid GameId, Color KingCastlingColor, CastlingDirection CastlingDirection);
}
