using Chess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesManagement.Interfaces
{
    public interface IGameStoreService
    {
        Task<Game> StartNewGameAsync(string whitePlayerEmail, string blackPlayerEmail);

        Task<Game> GetGameAsync(Guid gameId);

        Task<bool> GameExist(Guid gameId);
    }
}
