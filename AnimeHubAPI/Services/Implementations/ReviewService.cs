using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repo;
        public ReviewService(IReviewRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ReviewDto>> GetByAnimeIdAsync(int animeId) => 
            (await _repo.GetByAnimeIdAsync(animeId)).Select(MapToDto);

        public async Task<ReviewDto> CreateAsync(ReviewCreateDto dto)
        {
            var entity = new Review 
            { 
                AnimeId = dto.AnimeId, 
                UserId = dto.UserId, 
                Rating = dto.Rating, 
                Comment = dto.Comment 
            };
            await _repo.AddAsync(entity);
            var created = await _repo.GetByIdAsync(entity.Id);
            return MapToDto(created!);
        }

        private static ReviewDto MapToDto(Review r) => new()
        {
            Id = r.Id,
            AnimeId = r.AnimeId,
            AnimeTitle = r.Anime?.Title ?? string.Empty,
            UserId = r.UserId,
            Username = r.User?.Username ?? string.Empty,
            Rating = r.Rating,
            Comment = r.Comment,
            CreatedAt = r.CreatedAt
        };
    }
}