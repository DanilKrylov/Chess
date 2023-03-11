using Chess.Data.Interfaces;
using Chess.Store.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Store
{
    public static class StoreServiceRegister
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<ChessContext>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
        }
    }
}
