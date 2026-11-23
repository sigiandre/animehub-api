namespace AnimeHubAPI.Domain.DTOs
{
    public class AnimeVideoDto
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public string AnimeTitle { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public string VideoType { get; set; } = string.Empty;
        public int DurationSeconds { get; set; }
    }
}
