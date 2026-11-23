using AnimeHubAPI.Domain.Entities;

namespace AnimeHubAPI.Repositories.Interfaces
{
    public interface ISagaRepository
    {
        Task<IEnumerable<Saga>> GetByAnimeIdAsync(int animeId);
        Task<Saga?> GetByIdAsync(int id);
        Task<Saga> AddAsync(Saga entity);
    }
}
