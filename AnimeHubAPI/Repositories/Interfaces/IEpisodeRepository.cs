using AnimeHubAPI.Domain.Entities;

namespace AnimeHubAPI.Repositories.Interfaces
{
    public interface IEpisodeRepository
    {
        Task<IEnumerable<Episode>> GetBySagaIdAsync(int sagaId);
        Task<Episode?> GetByIdAsync(int id);
        Task<Episode> AddAsync(Episode entity);
    }
}
