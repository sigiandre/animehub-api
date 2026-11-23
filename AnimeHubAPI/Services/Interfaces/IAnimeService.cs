using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface IAnimeService
    {
        Task<IEnumerable<AnimeDto>> GetAllAsync();
        Task<AnimeDto?> GetByIdAsync(int id);
        Task<AnimeDto> CreateAsync(AnimeCreateDto dto);
    }
}
