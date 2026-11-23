using AnimeHubAPI.Domain.Entities;

namespace AnimeHubAPI.Repositories.Interfaces
{
    public interface IVoiceActorRepository
    {
        Task<IEnumerable<VoiceActor>> GetAllAsync();
        Task<VoiceActor?> GetByIdAsync(int id);
        Task<VoiceActor> AddAsync(VoiceActor entity);
    }
}
