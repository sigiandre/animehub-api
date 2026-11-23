using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface IEpisodeService
    {
        Task<IEnumerable<EpisodeDto>> GetBySagaIdAsync(int sagaId);
        Task<EpisodeDto> CreateAsync(EpisodeCreateDto dto);
    }
}