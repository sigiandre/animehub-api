namespace AnimeHubAPI.Domain.DTOs
{
    public class FavoriteDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AnimeId { get; set; }
        public string AnimeTitle { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public DateTime AddedAt { get; set; }
    }
}
