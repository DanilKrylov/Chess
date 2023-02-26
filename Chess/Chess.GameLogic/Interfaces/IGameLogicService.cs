﻿using Chess.Data.Enums;
using Chess.Data.Models;
using Chess.GameLogic.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Interfaces
{
    public interface IGameLogicService
    {
        Task MovePieceAsync(Guid gameId, PiecePositionDto from, PiecePositionDto to);
    }
}
