namespace AnimeHubAPI.Domain.DTOs
{
    public class MangakaCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string Country { get; set; } = "Japón";
        public DateTime? BirthDate { get; set; }
    }
}
