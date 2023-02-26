using Chess.Data.Enums;
using Chess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.DtoModels
{
    public record PiecePositionDto(int VerticalPosition, int HorizontalPosition);
}
