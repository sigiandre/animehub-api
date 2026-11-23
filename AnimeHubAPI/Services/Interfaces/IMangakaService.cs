using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface IMangakaService
    {
        Task<IEnumerable<MangakaDto>> GetAllAsync();
        Task<MangakaDto?> GetByIdAsync(int id);
        Task<MangakaDto> CreateAsync(MangakaCreateDto dto);
    }
}
