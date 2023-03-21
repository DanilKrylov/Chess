using Chess.Data.Models;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    public interface IRunningGamesService
    {
        bool TryAddRunningGame(GameDto game);

        bool TryRemoveRunningGame(Guid gameId);

        GameDto? GetRunningGame(Guid gameId);
    }
}
