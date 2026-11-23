using AnimeHubAPI.Domain.Entities;

namespace AnimeHubAPI.Repositories.Interfaces
{
    public interface IMangakaRepository
    {
        Task<IEnumerable<Mangaka>> GetAllAsync();
        Task<Mangaka?> GetByIdAsync(int id);
        Task<Mangaka> AddAsync(Mangaka mangaka);
        Task UpdateAsync(Mangaka mangaka);
        Task DeleteAsync(int id);
    }
}
