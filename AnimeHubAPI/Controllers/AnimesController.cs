using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimesController : ControllerBase
    {
        private readonly IAnimeService _service;
        public AnimesController(IAnimeService service) 
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() => 
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var anime = await _service.GetByIdAsync(id);
            if (anime == null) return NotFound();
            return Ok(anime);
        }

        [HttpPost]
        [Authorize] // Requiere token JWT
        public async Task<IActionResult> Create([FromBody] AnimeCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
