using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class StudioRepository : IStudioRepository
    {
        private readonly ApplicationDbContext _context;
        public StudioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Studio>> GetAllAsync() =>
            await _context.Studios.AsNoTracking().ToListAsync();

        public async Task<Studio?> GetByIdAsync(int id) =>
            await _context.Studios.FindAsync(id);

        public async Task<Studio> AddAsync(Studio entity)
        {
            _context.Studios.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Studio entity)
        {
            _context.Studios.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var e = await GetByIdAsync(id);
            if (e != null)
            {
                _context.Studios.Remove(e);
                await _context.SaveChangesAsync();
            }
        }
    }
}