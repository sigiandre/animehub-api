namespace AnimeHubAPI.Domain.DTOs
{
    public class VoiceActorCreateDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Language { get; set; } = "Japonés";
        public string PhotoUrl { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
    }
}
