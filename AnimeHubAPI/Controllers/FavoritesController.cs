using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _service;
        public FavoritesController(IFavoriteService service)
        {
            _service = service;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId) => 
            Ok(await _service.GetByUserIdAsync(userId));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FavoriteCreateDto dto)
        {
            try
            {
                return Ok(await _service.AddAsync(dto));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}