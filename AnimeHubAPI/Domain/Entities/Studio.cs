namespace AnimeHubAPI.Domain.Entities
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = "Japón";
        public int FoundedYear { get; set; }

        // Relaciones
        public ICollection<Anime> Animes { get; set; } = new List<Anime>();
    }
}
