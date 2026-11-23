namespace AnimeHubAPI.Domain.Entities
{
    public class Episode
    {
        public int Id { get; set; }
        public int SagaId { get; set; }
        public Saga Saga { get; set; } = null!;

        public int EpisodeNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Synopsis { get; set; } = string.Empty;
        public int DurationMinutes { get; set; } = 24;
        public DateTime? AirDate { get; set; }
    }
}
