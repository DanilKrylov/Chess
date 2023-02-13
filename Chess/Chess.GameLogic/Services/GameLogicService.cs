using Chess.Data.Enums;
using Chess.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Services
{
    internal class GameLogicService : IGameLogicService
    {
        public Task MovePieceAsync(Guid gameId, int oldVerticalPos, HorizontalPosition oldHorizontalPos, int verticalPos, HorizontalPosition horizontalPos)
        {
            throw new NotImplementedException();
        }
    }
}
