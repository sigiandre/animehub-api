using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetByAnimeIdAsync(int animeId);
        Task<ReviewDto> CreateAsync(ReviewCreateDto dto);
    }
}