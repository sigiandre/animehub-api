using AnimeHubAPI.Data;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeHubAPI.Repositories.Implementations
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;
        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notification>> GetByUserIdAsync(int userId) =>
            await _context.Notifications
            .Where(n => n.UserId == userId)
            .OrderByDescending(n => n.CreatedAt)
            .AsNoTracking()
            .ToListAsync();

        public async Task<Notification?> GetByIdAsync(int id) => 
            await _context.Notifications.FindAsync(id);

        public async Task<Notification> AddAsync(Notification entity) 
        { 
            _context.Notifications.Add(entity); 
            await _context.SaveChangesAsync(); 
            return entity; 
        }

        public async Task MarkAsReadAsync(int id)
        {
            var notif = await _context.Notifications.FindAsync(id);
            if (notif != null) 
            { 
                notif.IsRead = true;
                await _context.SaveChangesAsync(); 
            }
        }
    }
}