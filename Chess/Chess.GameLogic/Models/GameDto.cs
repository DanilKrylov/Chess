using Chess.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chess.GameLogic.Models
{
    public record class GameDto(Guid GameId, string WhitePlayerEmail, string BlackPlayerEmail, List<PieceDto> Pieces)
    {
        public Color MoveTurn { get; private set; } = Color.White;

        internal void ChangeMoveTurn() => MoveTurn = MoveTurn.GetOpposite();
    }
}
