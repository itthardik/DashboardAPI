using Microsoft.AspNetCore.SignalR;
namespace Dashboard.Services
{

    public class MqttHub : Hub
    {
        public async Task SendMessage(string topic, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", topic, message);
        }
    }

}
