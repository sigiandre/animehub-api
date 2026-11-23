namespace AnimeHubAPI.Domain.Entities
{
    public class ForumPost
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
