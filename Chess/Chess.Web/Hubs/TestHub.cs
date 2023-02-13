using Microsoft.AspNetCore.SignalR;

namespace Chess.Web.Hubs
{
    public class TestHub: Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
