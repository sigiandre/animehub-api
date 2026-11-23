using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetByAnimeIdAsync(int animeId) =>
            await _context.Reviews
                .Where(r => r.AnimeId == animeId)
                .Include(r => r.Anime)
                .Include(r => r.User)
                .OrderByDescending(r => r.CreatedAt)
                .AsNoTracking()
                .ToListAsync();

        public async Task<Review?> GetByIdAsync(int id) =>
            await _context.Reviews.Include(r => r.Anime).Include(r => r.User).FirstOrDefaultAsync(r => r.Id == id);

        public async Task<Review> AddAsync(Review entity) 
        { 
            _context.Reviews.Add(entity); 
            await _context.SaveChangesAsync(); 
            return entity; 
        }
    }
}