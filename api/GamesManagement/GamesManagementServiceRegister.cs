using Chess.GamesManagement.Interfaces;
using Chess.GamesManagement.Options;
using Chess.GamesManagement.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GamesManagement
{
    public static class GamesManagementServiceRegister
    {
        public static void  RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGameStoreService, GameStoreService>();
            services.AddSingleton<IGameSearcherService, GameSearcherService>();
            services.Configure<GameSearchConfigure>(configuration.GetSection("GameSearchConfigure"));
        }
    }
}
