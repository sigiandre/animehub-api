namespace AnimeHubAPI.Domain.DTOs
{
    public class MangakaDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
    }
}
