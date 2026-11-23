using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class SagaService : ISagaService
    {
        private readonly ISagaRepository _repo;
        public SagaService(ISagaRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<SagaDto>> GetByAnimeIdAsync(int animeId) => 
            (await _repo.GetByAnimeIdAsync(animeId)).Select(MapToDto);

        public async Task<SagaDto?> GetByIdAsync(int id)
        {
            var s = await _repo.GetByIdAsync(id);
            return s == null ? null : MapToDto(s);
        }

        public async Task<SagaDto> CreateAsync(SagaCreateDto dto)
        {
            var entity = new Saga 
            { 
                AnimeId = dto.AnimeId, 
                Title = dto.Title, 
                Description = dto.Description, 
                OrderIndex = dto.OrderIndex 
            };
            await _repo.AddAsync(entity);
            var created = await _repo.GetByIdAsync(entity.Id);
            return MapToDto(created!);
        }

        private static SagaDto MapToDto(Saga s) => new()
        {
            Id = s.Id,
            AnimeId = s.AnimeId,
            AnimeTitle = s.Anime?.Title ?? string.Empty,
            Title = s.Title,
            Description = s.Description,
            OrderIndex = s.OrderIndex,
            Episodes = s.Episodes.Select(e => new EpisodeDto
            {
                Id = e.Id,
                SagaId = e.SagaId,
                EpisodeNumber = e.EpisodeNumber,
                Title = e.Title,
                Synopsis = e.Synopsis,
                DurationMinutes = e.DurationMinutes,
                AirDate = e.AirDate
            }).ToList()
        };
    }
}