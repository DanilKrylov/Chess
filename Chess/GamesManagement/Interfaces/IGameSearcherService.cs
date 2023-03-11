using Chess.GamesManagement.DtoModels;

namespace Chess.GamesManagement.Interfaces
{
    public interface IGameSearcherService
    {
        bool TryAddPlayerToSearch(string email, int rating);

        bool TryRemovePlayerFromSearch(string email);

        PlayersMatch TryGetMatch(string email, int rating);
    }
}
