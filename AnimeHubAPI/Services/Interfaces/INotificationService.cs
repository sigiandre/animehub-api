using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetByUserIdAsync(int userId);
        Task<NotificationDto> CreateAsync(NotificationCreateDto dto);
        Task MarkAsReadAsync(int id);
    }
}