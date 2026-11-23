namespace AnimeHubAPI.Domain.DTOs
{
    public class CharacterCreateDto
    {
        public int AnimeId { get; set; }
        public int? VoiceActorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = "Protagonista";
        public string Biography { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
