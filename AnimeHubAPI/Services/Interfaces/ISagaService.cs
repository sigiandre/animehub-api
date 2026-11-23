using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface ISagaService
    {
        Task<IEnumerable<SagaDto>> GetByAnimeIdAsync(int animeId);
        Task<SagaDto?> GetByIdAsync(int id);
        Task<SagaDto> CreateAsync(SagaCreateDto dto);
    }
}
