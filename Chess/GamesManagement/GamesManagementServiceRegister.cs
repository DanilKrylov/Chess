using GamesManagement.Helpers;
using GamesManagement.Interfaces;
using GamesManagement.Options;
using GamesManagement.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesManagement
{
    public static class GamesManagementServiceRegister
    {
        public static void  RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGameCreator, DefaultGameCreator>();
            services.AddScoped<IGameStoreService, GameStoreService>();
            services.AddSingleton<IGameSearcherService, GameSearcherService>();
            services.Configure<GameSearchConfigure>(configuration.GetSection("GameSearchConfigure"));
        }
    }
}
