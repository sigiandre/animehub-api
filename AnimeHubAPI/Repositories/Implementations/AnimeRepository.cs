using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly ApplicationDbContext _context;
        public AnimeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Anime>> GetAllAsync() =>
            await _context.Animes
                .Include(a => a.Mangaka)
                .Include(a => a.Studio)
                .AsNoTracking()
                .ToListAsync();

        public async Task<Anime?> GetByIdAsync(int id) =>
            await _context.Animes
                .Include(a => a.Mangaka)
                .Include(a => a.Studio)
                .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<Anime> AddAsync(Anime entity) 
        { 
            _context.Animes.Add(entity); 
            await _context.SaveChangesAsync(); 
            return entity;
        }

        public async Task UpdateAsync(Anime entity)
        {
            _context.Animes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) 
        { 
            var e = await GetByIdAsync(id); 
            if (e != null) 
            { 
                _context.Animes.Remove(e); 
                await _context.SaveChangesAsync();
            } 
        }
    }
}