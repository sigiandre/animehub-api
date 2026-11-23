namespace AnimeHubAPI.Domain.DTOs
{
    public class SagaCreateDto
    {
        public int AnimeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
    }
}
