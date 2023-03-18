using Chess.Authorize;
using Chess.Data.Interfaces;
using Chess.GameLogic;
using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Services;
using Chess.Store;
using Chess.Store.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chess.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            GameLogicServiceRegister.RegisterServices(services, configuration);
            StoreServiceRegister.RegisterServices(services);
            AuthorizeServiceRegister.RegisterServices(services, configuration);
        }
    }
}