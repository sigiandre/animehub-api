using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _service;
        public ReviewsController(IReviewService service)
        {
            _service = service;
        }

        [HttpGet("anime/{animeId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByAnimeId(int animeId) => 
            Ok(await _service.GetByAnimeIdAsync(animeId));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ReviewCreateDto dto) => 
            Ok(await _service.CreateAsync(dto));
    }
}