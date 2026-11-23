using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface IVoiceActorService
    {
        Task<IEnumerable<VoiceActorDto>> GetAllAsync();
        Task<VoiceActorDto?> GetByIdAsync(int id);
        Task<VoiceActorDto> CreateAsync(VoiceActorCreateDto dto);
    }
}
