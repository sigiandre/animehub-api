namespace AnimeHubAPI.Domain.DTOs
{
    public class EpisodeCreateDto
    {
        public int SagaId { get; set; }
        public int EpisodeNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Synopsis { get; set; } = string.Empty;
        public int DurationMinutes { get; set; } = 24;
        public DateTime? AirDate { get; set; }
    }
}
