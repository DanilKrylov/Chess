using Chess.Data.Enums;

namespace Chess.GameLogic.Models
{
    public record class GameDto(Guid GameId, string WhitePlayerEmail, string BlackPlayerEmail, List<PieceDto> Pieces, GameResultInfo GameResult)
    {
        public Color MoveTurn { get; set; } = Color.White;

        internal void ChangeMoveTurn() => MoveTurn = MoveTurn.GetOpposite();
    }
}
