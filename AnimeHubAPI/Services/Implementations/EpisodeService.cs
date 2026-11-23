using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeRepository _repo;
        public EpisodeService(IEpisodeRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<EpisodeDto>> GetBySagaIdAsync(int sagaId) =>
            (await _repo.GetBySagaIdAsync(sagaId)).Select(e => new EpisodeDto
            {
                Id = e.Id,
                SagaId = e.SagaId,
                EpisodeNumber = e.EpisodeNumber,
                Title = e.Title,
                Synopsis = e.Synopsis,
                DurationMinutes = e.DurationMinutes,
                AirDate = e.AirDate
            });

        public async Task<EpisodeDto> CreateAsync(EpisodeCreateDto dto)
        {
            var entity = new Episode
            {
                SagaId = dto.SagaId,
                EpisodeNumber = dto.EpisodeNumber,
                Title = dto.Title,
                Synopsis = dto.Synopsis,
                DurationMinutes = dto.DurationMinutes,
                AirDate = dto.AirDate
            };
            await _repo.AddAsync(entity);
            return new EpisodeDto
            {
                Id = entity.Id,
                SagaId = entity.SagaId,
                EpisodeNumber = entity.EpisodeNumber,
                Title = entity.Title,
                Synopsis = entity.Synopsis,
                DurationMinutes = entity.DurationMinutes,
                AirDate = entity.AirDate
            };
        }
    }
}