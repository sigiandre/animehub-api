namespace AnimeHubAPI.Domain.Entities
{
    public class Ability
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; } = null!;

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DamageType { get; set; } = string.Empty; // Energía, Físico, Elemental
    }
}
