using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _repo;
        public FavoriteService(IFavoriteRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<FavoriteDto>> GetByUserIdAsync(int userId) =>
            (await _repo.GetByUserIdAsync(userId)).Select(f => new FavoriteDto
            {
                Id = f.Id,
                UserId = f.UserId,
                AnimeId = f.AnimeId,
                AnimeTitle = f.Anime?.Title ?? string.Empty,
                CoverImageUrl = f.Anime?.CoverImageUrl ?? string.Empty,
                AddedAt = f.AddedAt
            });

        public async Task<FavoriteDto> AddAsync(FavoriteCreateDto dto)
        {
            if (await _repo.ExistsAsync(dto.UserId, dto.AnimeId))
                throw new InvalidOperationException("Este anime ya está en tus favoritos.");

            var entity = new Favorite 
            { 
                UserId = dto.UserId, 
                AnimeId = dto.AnimeId 
            };
            await _repo.AddAsync(entity);
            return new FavoriteDto 
            { 
                Id = entity.Id, 
                UserId = entity.UserId, 
                AnimeId = entity.AnimeId, 
                AddedAt = entity.AddedAt 
            };
        }

        public async Task DeleteAsync(int id) => 
            await _repo.DeleteAsync(id);
    }
}