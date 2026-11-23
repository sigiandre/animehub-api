using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SagasController : ControllerBase
    {
        private readonly ISagaService _service;
        public SagasController(ISagaService service)
        {
            _service = service;
        }

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
        public async Task<IActionResult> Create([FromBody] SagaCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}