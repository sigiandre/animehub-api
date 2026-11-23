namespace AnimeHubAPI.Domain.DTOs
{
    public class SagaDto
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public string AnimeTitle { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public List<EpisodeDto> Episodes { get; set; } = new();
    }
}
