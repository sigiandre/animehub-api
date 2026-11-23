using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class ForumPostRepository : IForumPostRepository
    {
        private readonly ApplicationDbContext _context;
        public ForumPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ForumPost>> GetAllAsync() =>
            await _context.ForumPosts
            .Include(p => p.Anime)
            .Include(p => p.User)
            .OrderByDescending(p => p.CreatedAt)
            .AsNoTracking()
            .ToListAsync();

        public async Task<IEnumerable<ForumPost>> GetByAnimeIdAsync(int animeId) =>
            await _context.ForumPosts
            .Where(p => p.AnimeId == animeId)
            .Include(p => p.Anime)
            .Include(p => p.User)
            .OrderByDescending(p => p.CreatedAt)
            .AsNoTracking()
            .ToListAsync();

        public async Task<ForumPost?> GetByIdAsync(int id) =>
            await _context.ForumPosts
            .Include(p => p.Anime)
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<ForumPost> AddAsync(ForumPost entity) 
        { 
            _context.ForumPosts.Add(entity);
            await _context.SaveChangesAsync(); 
            return entity; 
        }
    }
}