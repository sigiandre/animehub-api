using AnimeHubAPI.Domain.Entities;

namespace AnimeHubAPI.Repositories.Interfaces
{
    public interface IForumPostRepository
    {
        Task<IEnumerable<ForumPost>> GetAllAsync();
        Task<IEnumerable<ForumPost>> GetByAnimeIdAsync(int animeId);
        Task<ForumPost?> GetByIdAsync(int id);
        Task<ForumPost> AddAsync(ForumPost entity);
    }
}