using Chess.Data.Models;
using GamesManagement.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesManagement.Interfaces
{
    public interface IGameSearcherService
    {
        bool TryAddPlayerToSearch(string email, int rating);

        bool TryRemovePlayerFromSearch(string email);

        PlayersMatchDto TryGetMatch(string email, int rating);
    }
}
