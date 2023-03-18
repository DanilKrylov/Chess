using Chess.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic.Interfaces
{
    public interface IGameSearcherService
    {
        bool TryAddPlayerToSearch(string email, int rating);

        bool TryRemovePlayerFromSearch(string email);

        PlayersMatch TryGetMatch(string email, int rating);
    }
}
