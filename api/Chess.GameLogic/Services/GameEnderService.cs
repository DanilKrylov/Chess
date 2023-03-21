using Chess.Data.Enums;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Models;

namespace Chess.GameLogic.Services
{
    internal class GameEnderService : IGameEnderService
    {
        private readonly IMoveValidator _moveValidator;
        private readonly IRunningGamesService _runningGamesService;
        private readonly ICheckMateDetector _checkMateDetector;
        private readonly IGameUpdaterService _gameUpdaterService;

        public GameEnderService(IMoveValidator moveValidator, IRunningGamesService runningGamesService, ICheckMateDetector checkMateDetector, IGameUpdaterService gameUpdaterService)
        {
            _moveValidator = moveValidator;
            _runningGamesService = runningGamesService;
            _checkMateDetector = checkMateDetector;
            _gameUpdaterService = gameUpdaterService;
        }

        public async Task<GameResultInfo> TryEndGameByCheckMateAsync(Guid gameId)
        {
            var game = _runningGamesService.GetRunningGame(gameId);
            var result = new GameResultInfo(false);

            if(_checkMateDetector.IsCheckMateInPos(game.Pieces, Color.White))
            {
                result = new GameResultInfo(true, false, game.BlackPlayerEmail);
            }

            if (_checkMateDetector.IsCheckMateInPos(game.Pieces, Color.Black))
            {
                result = new GameResultInfo(true, false, game.WhitePlayerEmail);
            }

            if (result.IsEnded)
                await EndGame(gameId, result);

            return result;
        }

        private async Task EndGame(Guid gameId, GameResultInfo result)
        {
            var gameDto = _runningGamesService.GetRunningGame(gameId);
            _runningGamesService.TryRemoveRunningGame(gameId);
            await _gameUpdaterService.UpdateGame(gameId, gameDto, result);
        }
    }
}
