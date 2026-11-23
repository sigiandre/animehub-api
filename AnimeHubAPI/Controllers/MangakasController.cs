using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangakasController : ControllerBase
    {
        private readonly IMangakaService _service;

        public MangakasController(IMangakaService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var mangakas = await _service.GetAllAsync();
            return Ok(mangakas);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var mangaka = await _service.GetByIdAsync(id);
            if (mangaka == null) return NotFound();
            return Ok(mangaka);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] MangakaCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}