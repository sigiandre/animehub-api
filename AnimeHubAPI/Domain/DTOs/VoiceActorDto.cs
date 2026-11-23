namespace AnimeHubAPI.Domain.DTOs
{
    public class VoiceActorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
    }
}
