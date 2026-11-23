using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => 
            await _context.Categories.AsNoTracking().ToListAsync();

        public async Task<Category?> GetByIdAsync(int id) => 
            await _context.Categories.FindAsync(id);

        public async Task<Category> AddAsync(Category entity) 
        { 
            _context.Categories.Add(entity); 
            await _context.SaveChangesAsync(); 
            return entity; 
        }

        public async Task AssignToAnimeAsync(int animeId, int categoryId)
        {
            var exists = await _context.AnimeCategories.AnyAsync(ac => ac.AnimeId == animeId && ac.CategoryId == categoryId);
            if (!exists)
            {
                _context.AnimeCategories.Add(new AnimeCategory 
                { 
                    AnimeId = animeId, 
                    CategoryId = categoryId 
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetByAnimeIdAsync(int animeId) =>
            await _context.AnimeCategories
                .Where(ac => ac.AnimeId == animeId)
                .Select(ac => ac.Category)
                .AsNoTracking()
                .ToListAsync();
    }
}