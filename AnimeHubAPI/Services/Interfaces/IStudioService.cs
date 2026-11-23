using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface IStudioService
    {
        Task<IEnumerable<StudioDto>> GetAllAsync();
        Task<StudioDto?> GetByIdAsync(int id);
        Task<StudioDto> CreateAsync(StudioCreateDto dto);
    }
}
