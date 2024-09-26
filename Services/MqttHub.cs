using Microsoft.AspNetCore.SignalR;
namespace Dashboard.Services
{
    /// <summary>
    /// MqttHub
    /// </summary>
    public class MqttHub : Hub
    {
        /// <summary>
        /// ssend Message to all connected client
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string topic, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", topic, message);
        }
    }

}
