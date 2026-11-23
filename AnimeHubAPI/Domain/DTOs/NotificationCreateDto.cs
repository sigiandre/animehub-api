namespace AnimeHubAPI.Domain.DTOs
{
    public class NotificationCreateDto
    {
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? RedirectUrl { get; set; }
    }
}