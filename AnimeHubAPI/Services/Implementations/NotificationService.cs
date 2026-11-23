using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repo;
        public NotificationService(INotificationRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<NotificationDto>> GetByUserIdAsync(int userId) =>
            (await _repo.GetByUserIdAsync(userId)).Select(n => new NotificationDto
            {
                Id = n.Id,
                UserId = n.UserId,
                Title = n.Title,
                Message = n.Message,
                IsRead = n.IsRead,
                RedirectUrl = n.RedirectUrl,
                CreatedAt = n.CreatedAt
            });

        public async Task<NotificationDto> CreateAsync(NotificationCreateDto dto)
        {
            var entity = new Notification { UserId = dto.UserId, Title = dto.Title, Message = dto.Message, RedirectUrl = dto.RedirectUrl };
            await _repo.AddAsync(entity);
            return new NotificationDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Title = entity.Title,
                Message = entity.Message,
                IsRead = entity.IsRead,
                RedirectUrl = entity.RedirectUrl,
                CreatedAt = entity.CreatedAt
            };
        }

        public async Task MarkAsReadAsync(int id) => 
            await _repo.MarkAsReadAsync(id);
    }
}