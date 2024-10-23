using Dashboard.Utility;
using MQTTnet;
using MQTTnet.Client;

namespace Dashboard.Services
{
    /// <summary>
    /// Mqtt Service
    /// </summary>
    public class MqttService
    {
        private readonly IMqttClient _mqttClient;
        private readonly IConfiguration _configuration;
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
        public MqttService(IConfiguration configuration)
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();

            _mqttClient.ConnectedAsync += OnConnectedAsync;
            _mqttClient.DisconnectedAsync += OnDisconnectedAsync;

            _configuration = configuration;

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
                    .WithCredentials(_configuration["DotNetMqttClient:Username"], _configuration["DotNetMqttClient:Password"])
                    .WithWebSocketServer(options =>
                    {
                        options.WithUri(_configuration["DotNetMqttClient:ConnectionUri"]);
                    })
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
                ex.LogException();
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