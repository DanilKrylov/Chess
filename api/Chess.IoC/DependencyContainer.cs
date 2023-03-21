using Chess.Authorize;
using Chess.GameLogic;
using Chess.Store;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chess.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            GameLogicServiceRegister.RegisterServices(services, configuration);
            StoreServiceRegister.RegisterServices(services, configuration);
            AuthorizeServiceRegister.RegisterServices(services, configuration);
        }
    }
}