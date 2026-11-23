using AnimeHubAPI.Domain.Entities;

namespace AnimeHubAPI.Repositories.Interfaces
{
    public interface IAnimeVideoRepository
    {
        Task<IEnumerable<AnimeVideo>> GetAllAsync();
        Task<IEnumerable<AnimeVideo>> GetByAnimeIdAsync(int animeId);
        Task<AnimeVideo?> GetByIdAsync(int id);
        Task<AnimeVideo> AddAsync(AnimeVideo entity);
    }
}
