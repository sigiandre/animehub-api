using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class MangakaRepository : IMangakaRepository
    {
        private readonly ApplicationDbContext _context;

        public MangakaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mangaka>> GetAllAsync() => 
            await _context.Mangakas.AsNoTracking().ToListAsync();

        public async Task<Mangaka?> GetByIdAsync(int id) => 
            await _context.Mangakas.FindAsync(id);

        public async Task<Mangaka> AddAsync(Mangaka entity)
        { 
            _context.Mangakas.Add(entity); 
            await _context.SaveChangesAsync(); 
            return entity; 
        }

        public async Task UpdateAsync(Mangaka entity) 
        { 
            _context.Mangakas.Update(entity); 
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id) 
        { 
            var e = await GetByIdAsync(id); 
            if (e != null)
            { 
                _context.Mangakas.Remove(e);
                await _context.SaveChangesAsync();
            }
        }
    }
}