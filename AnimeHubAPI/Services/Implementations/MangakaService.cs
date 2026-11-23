using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class MangakaService : IMangakaService
    {
        private readonly IMangakaRepository _repo;
        public MangakaService(IMangakaRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<MangakaDto>> GetAllAsync() => 
            (await _repo.GetAllAsync()).Select(m => new MangakaDto 
            { 
                Id = m.Id, 
                Name = m.Name, 
                Biography = m.Biography, 
                Country = m.Country, 
                BirthDate = m.BirthDate 
            });

        public async Task<MangakaDto?> GetByIdAsync(int id)
        { 
            var m = await _repo.GetByIdAsync(id); 
            return m == null ? null : new MangakaDto 
            { 
                Id = m.Id, 
                Name = m.Name, 
                Biography = m.Biography, 
                Country = m.Country,
                BirthDate = m.BirthDate 
            }; 
        }

        public async Task<MangakaDto> CreateAsync(MangakaCreateDto dto)
        {
            var entity = new Mangaka 
            { 
                Name = dto.Name, 
                Biography = dto.Biography, 
                Country = dto.Country, 
                BirthDate = dto.BirthDate 
            };
            await _repo.AddAsync(entity);
            return new MangakaDto 
            { 
                Id = entity.Id, 
                Name = entity.Name, 
                Biography = entity.Biography,
                Country = entity.Country, 
                BirthDate = entity.BirthDate 
            };
        }
    }
}