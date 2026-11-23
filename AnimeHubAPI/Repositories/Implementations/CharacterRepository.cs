using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ApplicationDbContext _context;
        public CharacterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Character>> GetAllAsync() =>
            await _context.Characters
                .Include(c => c.Anime)
                .Include(c => c.VoiceActor)
                .Include(c => c.Abilities)
                .AsNoTracking()
                .ToListAsync();

        public async Task<IEnumerable<Character>> GetByAnimeIdAsync(int animeId) =>
            await _context.Characters
                .Where(c => c.AnimeId == animeId)
                .Include(c => c.Anime)
                .Include(c => c.VoiceActor)
                .Include(c => c.Abilities)
                .AsNoTracking()
                .ToListAsync();

        public async Task<Character?> GetByIdAsync(int id) =>
            await _context.Characters
                .Include(c => c.Anime)
                .Include(c => c.VoiceActor)
                .Include(c => c.Abilities)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Character> AddAsync(Character entity) { _context.Characters.Add(entity); await _context.SaveChangesAsync(); return entity; }
    }
}
