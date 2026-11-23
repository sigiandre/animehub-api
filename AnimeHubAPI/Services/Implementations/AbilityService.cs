using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class AbilityService : IAbilityService
    {
        private readonly IAbilityRepository _repo;
        public AbilityService(IAbilityRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<AbilityDto>> GetAllAsync() =>
            (await _repo.GetAllAsync()).Select(a => new AbilityDto 
            { 
                Id = a.Id, 
                CharacterId = a.CharacterId, 
                Name = a.Name, 
                Description = a.Description, 
                DamageType = a.DamageType 
            });

        public async Task<IEnumerable<AbilityDto>> GetByCharacterIdAsync(int characterId) =>
            (await _repo.GetByCharacterIdAsync(characterId)).Select(a => 
            new AbilityDto 
            { 
                Id = a.Id, 
                CharacterId = a.CharacterId, 
                Name = a.Name, 
                Description = a.Description, 
                DamageType = a.DamageType 
            });

        public async Task<AbilityDto?> GetByIdAsync(int id)
        {
            var a = await _repo.GetByIdAsync(id);
            return a == null ? null : new AbilityDto 
            { 
                Id = a.Id, 
                CharacterId = a.CharacterId, 
                Name = a.Name, 
                Description = a.Description, 
                DamageType = a.DamageType 
            };
        }

        public async Task<AbilityDto> CreateAsync(AbilityCreateDto dto)
        {
            var entity = new Ability 
            { 
                CharacterId = dto.CharacterId, 
                Name = dto.Name, 
                Description = dto.Description, 
                DamageType = dto.DamageType 
            };
            await _repo.AddAsync(entity);
            return new AbilityDto 
            { 
                Id = entity.Id, 
                CharacterId = entity.CharacterId, 
                Name = entity.Name, 
                Description = entity.Description, 
                DamageType = entity.DamageType 
            };
        }
    }
}