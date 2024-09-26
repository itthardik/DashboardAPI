using MQTTnet;
using MQTTnet.Client;
using Microsoft.AspNetCore.SignalR;
using System.Text;

namespace Dashboard.Services
{
    /// <summary>
    /// Mqtt Service
    /// </summary>
    public class MqttService
    {
        private readonly IMqttClient _mqttClient;
        private readonly IHubContext<MqttHub> _hubContext;
        private readonly Timer _reconnectTimer;
        private bool _isReconnecting;
        private async void CheckConnectionStatus(object state)
        {
            if (!_mqttClient.IsConnected && !_isReconnecting)
            {
                _isReconnecting = true;
                Console.WriteLine("Attempting to reconnect...");
                await ConnectAsync();
            }
        }

        /// <summary>
        /// mqtt service constructor
        /// </summary>
        /// <param name="hubContext"></param>
        public MqttService(IHubContext<MqttHub> hubContext)
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
            _hubContext = hubContext;

            _mqttClient.ConnectedAsync += OnConnectedAsync;
            _mqttClient.DisconnectedAsync += OnDisconnectedAsync;
            _mqttClient.ApplicationMessageReceivedAsync += OnApplicationMessageReceivedAsync;

            _reconnectTimer = new Timer(CheckConnectionStatus!, null, Timeout.Infinite, (int)TimeSpan.FromSeconds(10).TotalMilliseconds);
        }


        private Task OnConnectedAsync(MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("Connected to MQTT broker via WebSocket.");
            _reconnectTimer.Change(Timeout.Infinite, Timeout.Infinite);
            _isReconnecting = false;
            return Task.CompletedTask;
        }

        private Task OnDisconnectedAsync(MqttClientDisconnectedEventArgs e)
        {
            Console.WriteLine("Disconnected from MQTT broker.");
            _reconnectTimer.Change(0, (int)TimeSpan.FromMinutes(1).TotalMilliseconds);
            return Task.CompletedTask;
        }

        private async Task OnApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs e)
        {
            var payloadArray = e.ApplicationMessage.PayloadSegment.ToArray();

            var payload = Encoding.UTF8.GetString(payloadArray);


            await _hubContext.Clients.All.SendAsync("ReceiveMessage", e.ApplicationMessage.Topic, payload);
        }
    
        /// <summary>
        /// Connect async with admin
        /// </summary>
        /// <returns></returns>
        public async Task ConnectAsync()
        {

            try
            {
                var mqttOptions = new MqttClientOptionsBuilder()
                    .WithClientId("DotNetClient")
                    .WithCredentials("admin", "admin")
                    .WithWebSocketServer(options =>
                    {
                        options.WithUri("ws://127.0.0.1:9001");
                    })
                    //.WithTcpServer("localhost")
                    .WithCleanSession(true)
                    .Build();
                var result = await _mqttClient.ConnectAsync(mqttOptions, CancellationToken.None);
                if (result.ResultCode == MqttClientConnectResultCode.Success)
                {
                    Console.WriteLine("Connected successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
                _isReconnecting = false;
            }
        }

        /// <summary>
        /// sub
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public async Task SubscribeAsync(string topic)
        {
            await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).Build());
            
        }

        /// <summary>
        /// pub
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task PublishAsync(string topic, string message)
        {
            var mqttMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(message)
                .Build();

            await _mqttClient.PublishAsync(mqttMessage);
        }
    }
}