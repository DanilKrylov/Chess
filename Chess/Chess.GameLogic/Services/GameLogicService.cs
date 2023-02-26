using Chess.Data.Enums;
using Chess.GameLogic.DtoModels;
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
        public Task MovePieceAsync(Guid gameId, PiecePositionDto from, PiecePositionDto to)
        {
            throw new NotImplementedException();
        }
    }
}
