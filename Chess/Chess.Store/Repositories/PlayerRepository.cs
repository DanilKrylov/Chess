using Chess.Data.Interfaces;
using Chess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Store.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ChessContext _db;

        public PlayerRepository(ChessContext db)
        {
            _db = db;
        }

        public Task AddPlayer(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
