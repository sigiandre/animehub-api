using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface IFavoriteService
    {
        Task<IEnumerable<FavoriteDto>> GetByUserIdAsync(int userId);
        Task<FavoriteDto> AddAsync(FavoriteCreateDto dto);
        Task DeleteAsync(int id);
    }
}