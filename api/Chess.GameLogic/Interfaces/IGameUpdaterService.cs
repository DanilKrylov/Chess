using Chess.Data.Models;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    internal interface IGameUpdaterService
    {
        Task UpdateGame(Guid gameId, GameDto gameDto, GameResultInfo gameResult);
    }
}
