using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeService _service;
        public EpisodesController(IEpisodeService service)
        {
            _service = service;
        }

        [HttpGet("saga/{sagaId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBySagaId(int sagaId) => 
            Ok(await _service.GetBySagaIdAsync(sagaId));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] EpisodeCreateDto dto) => 
            Ok(await _service.CreateAsync(dto));
    }
}