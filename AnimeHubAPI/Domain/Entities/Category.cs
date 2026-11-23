namespace AnimeHubAPI.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Shonen, Seinen, Isekai, Acción, etc.

        // Relaciones
        public ICollection<AnimeCategory> AnimeCategories { get; set; } = new List<AnimeCategory>();
    }
}
