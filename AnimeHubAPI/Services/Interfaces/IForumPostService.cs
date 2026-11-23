using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface IForumPostService
    {
        Task<IEnumerable<ForumPostDto>> GetAllAsync();
        Task<IEnumerable<ForumPostDto>> GetByAnimeIdAsync(int animeId);
        Task<ForumPostDto> CreateAsync(ForumPostCreateDto dto);
    }
}