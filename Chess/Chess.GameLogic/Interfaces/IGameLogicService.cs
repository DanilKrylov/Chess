using Chess.Data.Enums;
using Chess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Interfaces
{
    public interface IGameLogicService
    {
        Task MovePieceAsync(Guid gameId, int oldVerticalPos, HorizontalPosition oldHorizontalPos, int verticalPos, HorizontalPosition horizontalPos);
    }
}
