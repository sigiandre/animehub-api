using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterDto>> GetAllAsync();
        Task<IEnumerable<CharacterDto>> GetByAnimeIdAsync(int animeId);
        Task<CharacterDto?> GetByIdAsync(int id);
        Task<CharacterDto> CreateAsync(CharacterCreateDto dto);
    }
}
