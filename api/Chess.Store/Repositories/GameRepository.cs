using Chess.Data.Interfaces;
using Chess.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Chess.Store.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ChessContext _db;
        public GameRepository(ChessContext db) 
        {
            _db = db;
        }

        public async Task AddGameAsync(Game game)
        {
            _db.Games.Add(game);
            await _db.SaveChangesAsync();
        }

        public Task<Game> GetGameAsync(Guid gameId)
        {
            return _db.Games
                .Include(c => c.Pieces)
                .Include(c => c.BlackPlayer)
                .Include(c => c.WhitePlayer)
                .FirstAsync(c => c.GameId == gameId);
        }

        public async Task UpdateGameAsync(Game game, Guid gameId)
        {
            var gameToUpd = await _db.Games.FirstOrDefaultAsync(c => c.GameId == gameId);

            if(gameToUpd is null)
            {
                throw new ArgumentException("Incorrect gameId");
            }

            game.GameId = gameId;

            _db.Games.Update(game);
            await _db.SaveChangesAsync();
        }
    }
}
