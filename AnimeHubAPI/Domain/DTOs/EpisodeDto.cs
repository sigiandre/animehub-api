namespace AnimeHubAPI.Domain.DTOs
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public int SagaId { get; set; }
        public int EpisodeNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Synopsis { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public DateTime? AirDate { get; set; }
    }
}
