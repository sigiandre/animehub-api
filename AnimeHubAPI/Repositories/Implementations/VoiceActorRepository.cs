using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class VoiceActorRepository : IVoiceActorRepository
    {
        private readonly ApplicationDbContext _context;
        public VoiceActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VoiceActor>> GetAllAsync() => 
            await _context.VoiceActors.AsNoTracking().ToListAsync();

        public async Task<VoiceActor?> GetByIdAsync(int id) => 
            await _context.VoiceActors.FindAsync(id);

        public async Task<VoiceActor> AddAsync(VoiceActor entity) 
        { 
            _context.VoiceActors.Add(entity); 
            await _context.SaveChangesAsync(); 
            return entity; 
        }
    }
}
