using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class AnimeVideoRepository : IAnimeVideoRepository
    {
        private readonly ApplicationDbContext _context;
        public AnimeVideoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AnimeVideo>> GetAllAsync() =>
            await _context.AnimeVideos.Include(v => v.Anime).AsNoTracking().ToListAsync();

        public async Task<IEnumerable<AnimeVideo>> GetByAnimeIdAsync(int animeId) =>
            await _context.AnimeVideos.Where(v => v.AnimeId == animeId).Include(v => v.Anime).AsNoTracking().ToListAsync();

        public async Task<AnimeVideo?> GetByIdAsync(int id) =>
            await _context.AnimeVideos.Include(v => v.Anime).FirstOrDefaultAsync(v => v.Id == id);

        public async Task<AnimeVideo> AddAsync(AnimeVideo entity) 
        { 
            _context.AnimeVideos.Add(entity); 
            await _context.SaveChangesAsync(); 
            return entity;
        }
    }
}