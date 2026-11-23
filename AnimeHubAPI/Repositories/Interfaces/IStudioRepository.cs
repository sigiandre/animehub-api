using AnimeHubAPI.Domain.Entities;

namespace AnimeHubAPI.Repositories.Interfaces
{
    public interface IStudioRepository
    {
        Task<IEnumerable<Studio>> GetAllAsync();
        Task<Studio?> GetByIdAsync(int id);
        Task<Studio> AddAsync(Studio studio);
        Task UpdateAsync(Studio studio);
        Task DeleteAsync(int id);
    }
}
