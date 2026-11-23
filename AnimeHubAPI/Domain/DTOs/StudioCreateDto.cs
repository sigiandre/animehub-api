namespace AnimeHubAPI.Domain.DTOs
{
    public class StudioCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = "Japón";
        public int FoundedYear { get; set; }
    }
}
