using AnimeHubAPI.Domain.Entities;

namespace AnimeHubAPI.Repositories.Interfaces
{
    public interface IAnimeRepository
    {
        Task<IEnumerable<Anime>> GetAllAsync();
        Task<Anime?> GetByIdAsync(int id);
        Task<Anime> AddAsync(Anime anime);
        Task UpdateAsync(Anime anime);
        Task DeleteAsync(int id);
    }
}
