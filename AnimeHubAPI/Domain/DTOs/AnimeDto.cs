namespace AnimeHubAPI.Domain.DTOs
{
    public class AnimeDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Synopsis { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public string BannerImageUrl { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string Status { get; set; } = string.Empty;

        // Relaciones resumidas
        public MangakaDto? Mangaka { get; set; }
        public StudioDto? Studio { get; set; }
    }
}
