﻿using Dashboard.DataContext;
using Dashboard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Dashboard.Controllers
{

    [ApiController]

    [Route("api/[controller]")]
    public class MqttController(MqttService mqttService) : ControllerBase
    {
        private readonly MqttService _mqttService = mqttService;

        [Authorize]
        [HttpPost("publish")]
        public async Task<IActionResult> Publish(string topic, string message)
        {
            await _mqttService.PublishAsync(topic, message);
            return Ok(new { status = "Message Published" });
        }

        [Authorize]
        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe(string topic)
        {
            await _mqttService.SubscribeAsync(topic);
            return Ok(new { status = $"Subscribed to {topic}" });
        }
    }

}
