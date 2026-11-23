using AnimeHubAPI.Domain.Entities;

namespace AnimeHubAPI.Repositories.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<IEnumerable<Favorite>> GetByUserIdAsync(int userId);
        Task<bool> ExistsAsync(int userId, int animeId);
        Task<Favorite> AddAsync(Favorite entity);
        Task DeleteAsync(int id);
    }
}
