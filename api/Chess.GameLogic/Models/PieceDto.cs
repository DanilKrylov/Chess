using Chess.Data.Enums;

namespace Chess.GameLogic.Models
{
    public record PieceDto(PiecePositionDto Position, Color Color, PieceName Name)
    {
        public Guid PieceIdentifier { get; } = Guid.NewGuid();
        public bool IsMoved { get; private set; } = false;

        public void SetIsMoved()
        {
            IsMoved = true;
        }
    }
}
