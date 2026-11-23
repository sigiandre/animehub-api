using AnimeHubAPI.Domain.Entities;

namespace AnimeHubAPI.Repositories.Interfaces
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetAllAsync();
        Task<IEnumerable<Character>> GetByAnimeIdAsync(int animeId);
        Task<Character?> GetByIdAsync(int id);
        Task<Character> AddAsync(Character entity);
    }
}
