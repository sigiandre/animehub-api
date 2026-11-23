using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class ForumPostService : IForumPostService
    {
        private readonly IForumPostRepository _repo;
        public ForumPostService(IForumPostRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ForumPostDto>> GetAllAsync() => 
            (await _repo.GetAllAsync()).Select(MapToDto);

        public async Task<IEnumerable<ForumPostDto>> GetByAnimeIdAsync(int animeId) => 
            (await _repo.GetByAnimeIdAsync(animeId)).Select(MapToDto);

        public async Task<ForumPostDto> CreateAsync(ForumPostCreateDto dto)
        {
            var entity = new ForumPost 
            { 
                AnimeId = dto.AnimeId,
                UserId = dto.UserId,
                Title = dto.Title,
                Content = dto.Content 
            };
            await _repo.AddAsync(entity);
            var created = await _repo.GetByIdAsync(entity.Id);
            return MapToDto(created!);
        }

        private static ForumPostDto MapToDto(ForumPost p) => new()
        {
            Id = p.Id,
            AnimeId = p.AnimeId,
            AnimeTitle = p.Anime?.Title ?? string.Empty,
            UserId = p.UserId,
            Username = p.User?.Username ?? string.Empty,
            Title = p.Title,
            Content = p.Content,
            CreatedAt = p.CreatedAt
        };
    }
}