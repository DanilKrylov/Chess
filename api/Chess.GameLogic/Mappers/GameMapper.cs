using Chess.Data.Models;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Mappers
{
    internal static class GameMapper
    {
        public static GameDto MapToGameDto(Game game)
        {
            var pieceDtoes = PieceMapper.MapToPieceDtoes(game.Pieces).ToList();
            var gameResult = new GameResultInfo(game.IsEnded, game.IsDraw, game.WinnerPlayerEmail);
            return new GameDto(game.GameId, game.WhitePlayer.Email, game.BlackPlayer.Email, pieceDtoes, gameResult)
            {
                MoveTurn = game.MoveTurn,
            };
        }
    }
}
