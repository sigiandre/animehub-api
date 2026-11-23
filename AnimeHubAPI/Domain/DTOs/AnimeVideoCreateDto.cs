namespace AnimeHubAPI.Domain.DTOs
{
    public class AnimeVideoCreateDto
    {
        public int AnimeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public string VideoType { get; set; } = "Opening";
        public int DurationSeconds { get; set; }
    }
}
