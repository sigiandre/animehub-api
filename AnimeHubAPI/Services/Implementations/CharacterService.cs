using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _repo;
        public CharacterService(ICharacterRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CharacterDto>> GetAllAsync() 
            => (await _repo.GetAllAsync()).Select(MapToDto);
        
        public async Task<IEnumerable<CharacterDto>> GetByAnimeIdAsync(int animeId) => 
            (await _repo.GetByAnimeIdAsync(animeId)).Select(MapToDto);

        public async Task<CharacterDto?> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            return c == null ? null : MapToDto(c);
        }

        public async Task<CharacterDto> CreateAsync(CharacterCreateDto dto)
        {
            var entity = new Character
            {
                AnimeId = dto.AnimeId,
                VoiceActorId = dto.VoiceActorId,
                Name = dto.Name,
                Role = dto.Role,
                Biography = dto.Biography,
                ImageUrl = dto.ImageUrl
            };
            await _repo.AddAsync(entity);
            var created = await _repo.GetByIdAsync(entity.Id);
            return MapToDto(created!);
        }

        private static CharacterDto MapToDto(Character c) => new()
        {
            Id = c.Id,
            AnimeId = c.AnimeId,
            AnimeTitle = c.Anime?.Title ?? string.Empty,
            Name = c.Name,
            Role = c.Role,
            Biography = c.Biography,
            ImageUrl = c.ImageUrl,
            VoiceActor = c.VoiceActor == null ? null : new VoiceActorDto
            {
                Id = c.VoiceActor.Id,
                FullName = c.VoiceActor.FullName,
                Language = c.VoiceActor.Language,
                PhotoUrl = c.VoiceActor.PhotoUrl,
                BirthDate = c.VoiceActor.BirthDate
            },
            Abilities = c.Abilities.Select(a => new AbilityDto
            {
                Id = a.Id,
                CharacterId = a.CharacterId,
                Name = a.Name,
                Description = a.Description,
                DamageType = a.DamageType
            }).ToList()
        };
    }
}