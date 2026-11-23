namespace AnimeHubAPI.Domain.Entities
{
    public class AnimeCategory
    {
        public int AnimeId { get; set; }
        public Anime Anime { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
