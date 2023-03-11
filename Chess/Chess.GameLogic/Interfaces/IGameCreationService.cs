using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Interfaces
{
    public interface IGameCreationService
    {
        Task<GameDto> StartNewGameAsync(string whitePlayerEmail, string blackPlayerEmail);
    }
}
