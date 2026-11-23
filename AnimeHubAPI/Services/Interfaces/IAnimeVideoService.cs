using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface IAnimeVideoService
    {
        Task<IEnumerable<AnimeVideoDto>> GetAllAsync();
        Task<IEnumerable<AnimeVideoDto>> GetByAnimeIdAsync(int animeId);
        Task<AnimeVideoDto?> GetByIdAsync(int id);
        Task<AnimeVideoDto> CreateAsync(AnimeVideoCreateDto dto);
    }
}
