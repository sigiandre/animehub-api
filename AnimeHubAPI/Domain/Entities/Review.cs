namespace AnimeHubAPI.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int Rating { get; set; } // 1 a 10
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
