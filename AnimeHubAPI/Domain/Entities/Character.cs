namespace AnimeHubAPI.Domain.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; } = null!;

        public int? VoiceActorId { get; set; }
        public VoiceActor? VoiceActor { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = "Protagonista"; // Protagonista, Antagonista, Secundario
        public string Biography { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        // Relaciones
        public ICollection<Ability> Abilities { get; set; } = new List<Ability>();
    }
}
