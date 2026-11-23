using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface IAbilityService
    {
        Task<IEnumerable<AbilityDto>> GetAllAsync();
        Task<IEnumerable<AbilityDto>> GetByCharacterIdAsync(int characterId);
        Task<AbilityDto?> GetByIdAsync(int id);
        Task<AbilityDto> CreateAsync(AbilityCreateDto dto);
    }
}
