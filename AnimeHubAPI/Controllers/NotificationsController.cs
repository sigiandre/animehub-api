using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _service;
        public NotificationsController(INotificationService service)
        {
            _service = service;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId) =>
            Ok(await _service.GetByUserIdAsync(userId));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NotificationCreateDto dto) =>
            Ok(await _service.CreateAsync(dto));

        [HttpPatch("{id}/read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            await _service.MarkAsReadAsync(id);
            return NoContent();
        }
    }
}