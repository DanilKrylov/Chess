using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    public interface IGameCreationService
    {
        Task<GameDto> StartNewGameAsync(string whitePlayerEmail, string blackPlayerEmail);
    }
}
