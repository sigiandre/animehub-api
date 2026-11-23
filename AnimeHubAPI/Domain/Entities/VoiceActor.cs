namespace AnimeHubAPI.Domain.Entities
{
    public class VoiceActor
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Language { get; set; } = "Japonés"; // Japonés, Español Latino, Inglés
        public string PhotoUrl { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }

        // Relaciones
        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
