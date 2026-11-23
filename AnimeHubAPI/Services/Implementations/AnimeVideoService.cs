using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class AnimeVideoService : IAnimeVideoService
    {
        private readonly IAnimeVideoRepository _repo;
        public AnimeVideoService(IAnimeVideoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<AnimeVideoDto>> GetAllAsync() => 
            (await _repo.GetAllAsync()).Select(MapToDto);

        public async Task<IEnumerable<AnimeVideoDto>> GetByAnimeIdAsync(int animeId) => 
            (await _repo.GetByAnimeIdAsync(animeId)).Select(MapToDto);

        public async Task<AnimeVideoDto?> GetByIdAsync(int id)
        {
            var v = await _repo.GetByIdAsync(id);
            return v == null ? null : MapToDto(v);
        }

        public async Task<AnimeVideoDto> CreateAsync(AnimeVideoCreateDto dto)
        {
            var entity = new AnimeVideo
            {
                AnimeId = dto.AnimeId,
                Title = dto.Title,
                VideoUrl = dto.VideoUrl,
                ThumbnailUrl = dto.ThumbnailUrl,
                VideoType = dto.VideoType,
                DurationSeconds = dto.DurationSeconds
            };
            await _repo.AddAsync(entity);
            var created = await _repo.GetByIdAsync(entity.Id);
            return MapToDto(created!);
        }

        private static AnimeVideoDto MapToDto(AnimeVideo v) => new()
        {
            Id = v.Id,
            AnimeId = v.AnimeId,
            AnimeTitle = v.Anime?.Title ?? string.Empty,
            Title = v.Title,
            VideoUrl = v.VideoUrl,
            ThumbnailUrl = v.ThumbnailUrl,
            VideoType = v.VideoType,
            DurationSeconds = v.DurationSeconds
        };
    }
}