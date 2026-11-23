namespace AnimeHubAPI.Domain.Entities
{
    public class AnimeVideo
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; } = null!;

        public string Title { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public string VideoType { get; set; } = "Opening"; // Opening, Ending, Trailer, Clip, AMV
        public int DurationSeconds { get; set; }
    }
}
