using Chess.Data.Models;

namespace Chess.GamesManagement.Interfaces
{
    public interface IGameStoreService
    {
        Task<Game> GetGameAsync(Guid gameId);

        Task<bool> GameExist(Guid gameId);
    }
}
