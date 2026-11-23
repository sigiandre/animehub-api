using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeVideosController : ControllerBase
    {
        private readonly IAnimeVideoService _service;
        public AnimeVideosController(IAnimeVideoService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() => 
            Ok(await _service.GetAllAsync());

        [HttpGet("anime/{animeId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByAnimeId(int animeId) => 
            Ok(await _service.GetByAnimeIdAsync(animeId));

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] AnimeVideoCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
