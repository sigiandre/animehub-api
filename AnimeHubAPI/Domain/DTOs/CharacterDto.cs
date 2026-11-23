namespace AnimeHubAPI.Domain.DTOs
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public string AnimeTitle { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public VoiceActorDto? VoiceActor { get; set; }
        public List<AbilityDto> Abilities { get; set; } = new();
    }
}
