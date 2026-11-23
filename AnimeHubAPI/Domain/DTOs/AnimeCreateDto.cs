namespace AnimeHubAPI.Domain.DTOs
{
    public class AnimeCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Synopsis { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public string BannerImageUrl { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string Status { get; set; } = "Finalizado";
        public int? MangakaId { get; set; }
        public int? StudioId { get; set; }
    }
}
