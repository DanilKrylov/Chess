using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Models
{
    internal record GameDto(Guid Game, string WhitePlayerEmail, string BlackPlayerEmail, List<PieceDto> Pieces);
}
