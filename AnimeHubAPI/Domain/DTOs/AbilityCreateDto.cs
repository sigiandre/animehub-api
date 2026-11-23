namespace AnimeHubAPI.Domain.DTOs
{
    public class AbilityCreateDto
    {
        public int CharacterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DamageType { get; set; } = string.Empty;
    }
}
