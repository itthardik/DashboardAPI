using Dashboard.DataContext;
using Dashboard.Models.DTOs.Request;
using Dashboard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace Dashboard.Controllers
{
    /// <summary>
    /// Mqtt Controller
    /// </summary>
    /// <param name="mqttService"></param>
    [ApiController]
    [Route("api/[controller]")]
    public class MqttController(MqttService mqttService) : ControllerBase
    {
        private readonly MqttService _mqttService = mqttService;

        /// <summary>
        /// Publish New Message
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [Authorize(Policy = "FullAccessPolicy")]
        [HttpPost("publish")]
        public async Task<IActionResult> Publish(string topic, string message)
        {
            await _mqttService.PublishAsync(topic, message);
            return Ok(new { status = "Message Published" });
        }

        /// <summary>
        /// Sub topic
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        [Authorize(Policy = "FullAccessPolicy")]
        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe(string topic)
        {
            await _mqttService.SubscribeAsync(topic);
            return Ok(new { status = $"Subscribed to {topic}" });
        }
    }

}
