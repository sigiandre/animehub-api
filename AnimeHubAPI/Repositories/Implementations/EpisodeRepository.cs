using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly ApplicationDbContext _context;
        public EpisodeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Episode>> GetBySagaIdAsync(int sagaId) =>
            await _context.Episodes
            .Where(e => e.SagaId == sagaId)
            .OrderBy(e => e.EpisodeNumber).AsNoTracking().ToListAsync();

        public async Task<Episode?> GetByIdAsync(int id) => 
            await _context.Episodes.FindAsync(id);

        public async Task<Episode> AddAsync(Episode entity) 
        { 
            _context.Episodes.Add(entity); 
            await _context.SaveChangesAsync(); 
            return entity; 
        }
    }
}