using Chess.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Models
{
    public record CastlingInfo(Guid GameId, Color KingCastlingColor, CastlingDirection CastlingDirection);
}
