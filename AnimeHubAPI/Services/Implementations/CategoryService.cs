using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync() =>
            (await _repo.GetAllAsync()).Select(c => new CategoryDto 
            { 
                Id = c.Id, 
                Name = c.Name 
            });

        public async Task<IEnumerable<CategoryDto>> GetByAnimeIdAsync(int animeId) =>
            (await _repo.GetByAnimeIdAsync(animeId))
            .Select(c => new CategoryDto 
            { 
                Id = c.Id, 
                Name = c.Name 
            });

        public async Task<CategoryDto> CreateAsync(CategoryCreateDto dto)
        {
            var entity = new Category { Name = dto.Name };
            await _repo.AddAsync(entity);
            return new CategoryDto { Id = entity.Id, Name = entity.Name };
        }

        public async Task AssignToAnimeAsync(AssignCategoryDto dto) =>
            await _repo.AssignToAnimeAsync(dto.AnimeId, dto.CategoryId);
    }
}