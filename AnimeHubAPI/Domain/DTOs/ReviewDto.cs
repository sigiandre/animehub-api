namespace AnimeHubAPI.Domain.DTOs
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public string AnimeTitle { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
