using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class SagaRepository : ISagaRepository
    {
        private readonly ApplicationDbContext _context;
        public SagaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Saga>> GetByAnimeIdAsync(int animeId) =>
            await _context.Sagas
                .Where(s => s.AnimeId == animeId)
                .OrderBy(s => s.OrderIndex)
                .Include(s => s.Anime)
                .Include(s => s.Episodes.OrderBy(e => e.EpisodeNumber))
                .AsNoTracking()
                .ToListAsync();

        public async Task<Saga?> GetByIdAsync(int id) =>
            await _context.Sagas
                .Include(s => s.Anime)
                .Include(s => s.Episodes.OrderBy(e => e.EpisodeNumber))
                .FirstOrDefaultAsync(s => s.Id == id);

        public async Task<Saga> AddAsync(Saga entity) 
        { 
            _context.Sagas.Add(entity); 
            await _context.SaveChangesAsync(); 
            return entity; 
        }
    }
}