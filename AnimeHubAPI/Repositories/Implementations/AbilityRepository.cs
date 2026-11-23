using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class AbilityRepository : IAbilityRepository
    {
        private readonly ApplicationDbContext _context;
        public AbilityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ability>> GetAllAsync() => 
            await _context.Abilities.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Ability>> GetByCharacterIdAsync(int characterId) =>
            await _context.Abilities.Where(a => a.CharacterId == characterId).AsNoTracking().ToListAsync();
        
        public async Task<Ability?> GetByIdAsync(int id) => 
            await _context.Abilities.FindAsync(id);

        public async Task<Ability> AddAsync(Ability entity) 
        { 
            _context.Abilities.Add(entity); 
            await _context.SaveChangesAsync(); 
            return entity;
        }
    }
}