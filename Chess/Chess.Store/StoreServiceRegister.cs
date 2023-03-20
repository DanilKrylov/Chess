using Chess.Data.Interfaces;
using Chess.Store.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chess.Store
{
    public static class StoreServiceRegister
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChessContext>(opt => 
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IGameRepository, GameRepository>();
        }
    }
}
