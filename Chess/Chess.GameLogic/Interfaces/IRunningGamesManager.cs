using Chess.Data.Models;

namespace Chess.GameLogic.Interfaces
{
    internal interface IRunningGamesService
    {
        bool TryAddRunningGame(Game game);

        bool TryRemoveRunningGame(Guid gameId);

        bool TryUpdateRunningGame(Guid gameId, Game game);

        Game GetRunningGame(Guid gameId);
    }
}
