using Chess.Authorize;
using Chess.Data.Interfaces;
using Chess.GameLogic;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Services;
using Chess.Store;
using Chess.Store.Repositories;
using GamesManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chess.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChessContext>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPieceRepository, PieceRepository>();
            GamesManagementServiceRegister.RegisterServices(services, configuration);
            GameLogicServiceRegister.RegisterServices(services);
            AuthorizeServiceRegister.RegisterServices(services, configuration);
        }
    }
}