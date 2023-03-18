using Chess.GameLogic.Detectors;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.MoveValidators;
using Chess.GameLogic.Options;
using Chess.GameLogic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.GameLogic
{
    public static class GameLogicServiceRegister
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(typeof(IAvailableCagesDetector), GetBuildedAvailableCagesDetector());
            services.AddSingleton<ICheckDetector, CheckDetector>();
            services.AddSingleton<IBasicMoveValidator, BasicMoveValidator>();
            services.AddSingleton<ICheckAfterMoveValidator, CheckAfterMoveValidator>();
            services.AddSingleton<IMoveValidator, MoveValidator>();
            services.AddSingleton<IMoveInAvailableCagesValidator, MoveInAvailableCagesValidator>();
            services.AddSingleton<IRunningGamesService, RunningGameManager>();
            services.AddSingleton<ICheckMateDetector, CheckMateDetector>();
            services.AddSingleton<IGameSearcherService, GameSearcherService>();
            services.AddSingleton<IPieceMoverService, PieceMoverService>();

            services.AddScoped<IGameUpdaterService, GameUpdaterService>();
            services.AddScoped<IGameEnderService, GameEnderService>();
            services.AddScoped<IGameCreationService, DefaultGameCreationService>();
            services.AddScoped<IGameStoreService, GameStoreService>();
            services.Configure<GameSearchConfigure>(configuration.GetSection("GameSearchConfigure"));
        }

        private static AvailableCagesDetector GetBuildedAvailableCagesDetector()
        {
            var availableCagesHelper = new AvailableCagesHelper();
            var bishopDetector = new BishopAvailableCagesDetector(availableCagesHelper);
            var rookDetector = new RookAvailableCagesDetector(availableCagesHelper);
            var queenDetector = new QueenAvailableCagesDetector(rookDetector, bishopDetector);
            var availableCagesDetectorBuilder = new AvailableCagesDetectorBuilder();

            return availableCagesDetectorBuilder
                        .AddDetector(bishopDetector)
                        .AddDetector(rookDetector)
                        .AddDetector(queenDetector)
                        .AddDetector(new KnightAvailableCagesDetector())
                        .AddDetector(new PawnAvailableCagesDetector())
                        .AddDetector(new KingAvailableCagesDetector())
                        .Build();
        }
    }
}
