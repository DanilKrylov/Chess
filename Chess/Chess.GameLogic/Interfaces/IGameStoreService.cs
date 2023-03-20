using Chess.Data.Models;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    public interface IGameStoreService
    {
        Task<GameDto> GetGameAsync(Guid gameId);
    }
}
