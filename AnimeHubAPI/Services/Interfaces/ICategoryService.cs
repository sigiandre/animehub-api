using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<IEnumerable<CategoryDto>> GetByAnimeIdAsync(int animeId);
        Task<CategoryDto> CreateAsync(CategoryCreateDto dto);
        Task AssignToAnimeAsync(AssignCategoryDto dto);
    }
}
