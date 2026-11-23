using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class StudioService : IStudioService
    {
        private readonly IStudioRepository _repo;
        public StudioService(IStudioRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<StudioDto>> GetAllAsync() =>
            (await _repo.GetAllAsync()).Select(s => new StudioDto
            {
                Id = s.Id,
                Name = s.Name,
                Country = s.Country,
                FoundedYear = s.FoundedYear
            });

        public async Task<StudioDto?> GetByIdAsync(int id)
        {
            var s = await _repo.GetByIdAsync(id); 
            return s == null ? null : new StudioDto 
            { 
                Id = s.Id, 
                Name = s.Name, 
                Country = s.Country, 
                FoundedYear = s.FoundedYear 
            };
        }

        public async Task<StudioDto> CreateAsync(StudioCreateDto dto)
        {
            var entity = new Studio 
            { 
                Name = dto.Name, 
                Country = dto.Country, 
                FoundedYear = dto.FoundedYear
            };
            await _repo.AddAsync(entity);
            return new StudioDto 
            { 
                Id = entity.Id, 
                Name = entity.Name, 
                Country = entity.Country, 
                FoundedYear = entity.FoundedYear 
            };
        }
    }
}