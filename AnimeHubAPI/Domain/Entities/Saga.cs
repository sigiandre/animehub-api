namespace AnimeHubAPI.Domain.Entities
{
    public class Saga
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; } = null!;

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderIndex { get; set; }

        // Relaciones
        public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
