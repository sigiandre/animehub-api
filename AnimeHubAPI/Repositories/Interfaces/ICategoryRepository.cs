using AnimeHubAPI.Domain.Entities;

namespace AnimeHubAPI.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> AddAsync(Category entity);
        Task AssignToAnimeAsync(int animeId, int categoryId);
        Task<IEnumerable<Category>> GetByAnimeIdAsync(int animeId);
    }
}