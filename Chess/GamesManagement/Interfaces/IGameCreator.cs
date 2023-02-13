using Chess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesManagement.Interfaces
{
    public interface IGameCreator
    {
        Task<Game> CreateGameAsync(string whitePlayerEmail, string blackPlayerEmail);
    }
}

