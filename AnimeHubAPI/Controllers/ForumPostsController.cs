using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumPostsController : ControllerBase
    {
        private readonly IForumPostService _service;
        public ForumPostsController(IForumPostService service)
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
        public async Task<IActionResult> Create([FromBody] ForumPostCreateDto dto) => 
            Ok(await _service.CreateAsync(dto));
    }
}