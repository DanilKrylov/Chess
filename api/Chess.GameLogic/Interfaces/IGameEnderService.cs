using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    public interface IGameEnderService
    {
        Task<GameResultInfo> TryEndGameByCheckMateAsync(Guid guid);
    }
}
