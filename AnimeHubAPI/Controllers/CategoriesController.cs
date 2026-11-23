using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto dto) => 
            Ok(await _service.CreateAsync(dto));

        [HttpPost("assign")]
        [Authorize]
        public async Task<IActionResult> AssignToAnime([FromBody] AssignCategoryDto dto)
        {
            await _service.AssignToAnimeAsync(dto);
            return Ok(new { message = "Categoría asignada correctamente." });
        }
    }
}