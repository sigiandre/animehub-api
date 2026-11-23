using AnimeHubAPI.Domain.Entities;

namespace AnimeHubAPI.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetByAnimeIdAsync(int animeId);
        Task<Review?> GetByIdAsync(int id);
        Task<Review> AddAsync(Review entity);
    }
}