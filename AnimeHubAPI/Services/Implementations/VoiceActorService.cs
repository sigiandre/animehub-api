using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class VoiceActorService : IVoiceActorService
    {
        private readonly IVoiceActorRepository _repo;
        public VoiceActorService(IVoiceActorRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<VoiceActorDto>> GetAllAsync() =>
            (await _repo.GetAllAsync()).Select(v => new VoiceActorDto { Id = v.Id, FullName = v.FullName, Language = v.Language, PhotoUrl = v.PhotoUrl, BirthDate = v.BirthDate });

        public async Task<VoiceActorDto?> GetByIdAsync(int id)
        {
            var v = await _repo.GetByIdAsync(id);
            return v == null ? null : new VoiceActorDto 
            { 
                Id = v.Id, 
                FullName = v.FullName, 
                Language = v.Language, 
                PhotoUrl = v.PhotoUrl, 
                BirthDate = v.BirthDate 
            };
        }

        public async Task<VoiceActorDto> CreateAsync(VoiceActorCreateDto dto)
        {
            var entity = new VoiceActor 
            { 
                FullName = dto.FullName, 
                Language = dto.Language, 
                PhotoUrl = dto.PhotoUrl, 
                BirthDate = dto.BirthDate 
            };
            await _repo.AddAsync(entity);
            return new VoiceActorDto 
            { 
                Id = entity.Id, 
                FullName = entity.FullName, 
                Language = entity.Language, 
                PhotoUrl = entity.PhotoUrl, 
                BirthDate = entity.BirthDate 
            };
        }
    }
}
