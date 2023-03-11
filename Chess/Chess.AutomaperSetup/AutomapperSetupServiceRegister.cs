using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chess.AutomaperSetup
{
    public class AutomapperSetupServiceRegister
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppMappingProfile));
        }
    }
}