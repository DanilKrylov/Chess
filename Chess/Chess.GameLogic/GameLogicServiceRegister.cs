using Chess.GameLogic.Interfaces;
using Chess.GameLogic.Services;
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
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IGameLogicService, GameLogicService>();
        }
    }
}
