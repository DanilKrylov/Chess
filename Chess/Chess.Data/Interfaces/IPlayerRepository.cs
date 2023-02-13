using Chess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Data.Interfaces
{
    public interface IPlayerRepository
    {
        Task AddPlayer(Player player);
    }
}
