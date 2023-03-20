using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    public interface IGameSearcherService
    {
        bool TryAddPlayerToSearch(string email, int rating);

        bool TryRemovePlayerFromSearch(string email);

        PlayersMatch TryGetMatch(string email, int rating);
    }
}
