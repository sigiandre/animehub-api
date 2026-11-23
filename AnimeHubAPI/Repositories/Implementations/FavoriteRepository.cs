using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly ApplicationDbContext _context;
        public FavoriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Favorite>> GetByUserIdAsync(int userId) =>
            await _context.Favorites
                .Where(f => f.UserId == userId)
                .Include(f => f.Anime)
                .OrderByDescending(f => f.AddedAt)
                .AsNoTracking()
                .ToListAsync();

        public async Task<bool> ExistsAsync(int userId, int animeId) =>
            await _context.Favorites.AnyAsync(f => f.UserId == userId && f.AnimeId == animeId);

        public async Task<Favorite> AddAsync(Favorite entity) 
        { 
            _context.Favorites.Add(entity); 
            await _context.SaveChangesAsync(); 
            return entity; 
        }

        public async Task DeleteAsync(int id)
        {
            var fav = await _context.Favorites.FindAsync(id);
            if (fav != null) 
            { 
                _context.Favorites.Remove(fav); 
                await _context.SaveChangesAsync(); 
            }
        }
    }
}