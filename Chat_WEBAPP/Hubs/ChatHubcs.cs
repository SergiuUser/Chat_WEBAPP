using Microsoft.AspNetCore.SignalR;

namespace Chat_WEBAPP.Hubs
{
    public class ChatHubcs : Hub
    {
        public Task SendMessage(string user , string message)
        {
            return Clients.All.SendAsync("ReciveOne", user, message);
        }
    }
}
