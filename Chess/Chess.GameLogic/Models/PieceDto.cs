using Chess.Data.Enums;
using Chess.GameLogic.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Models
{
    internal record PieceDto(PiecePositionDto Position, Color Color, PieceName Name);
}
