using Chess.GameLogic.Models;

namespace Chess.GameLogic.Interfaces
{
    public interface IGameLogicService
    {
        bool TryMovePiece(PieceMoveInfo pieceMoveInfo, string playerEmail, out GameDto gameAfterMove);

        Task<GameResultInfo> TryEndGameByCheckMateAsync(Guid guid);
    }
}
