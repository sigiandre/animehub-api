using AnimeHubAPI.Domain.Entities;

namespace AnimeHubAPI.Repositories.Interfaces
{
    public interface IAbilityRepository
    {
        Task<IEnumerable<Ability>> GetAllAsync();
        Task<IEnumerable<Ability>> GetByCharacterIdAsync(int characterId);
        Task<Ability?> GetByIdAsync(int id);
        Task<Ability> AddAsync(Ability entity);
    }
}
