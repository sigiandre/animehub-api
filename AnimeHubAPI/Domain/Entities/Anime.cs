namespace AnimeHubAPI.Domain.Entities
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Synopsis { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public string BannerImageUrl { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string Status { get; set; } = "Finalizado"; // En emisión, Finalizado, Próximamente

        // Claves Foráneas
        public int? MangakaId { get; set; }
        public Mangaka? Mangaka { get; set; }

        // Claves Foráneas
        public int? StudioId { get; set; }
        public Studio? Studio { get; set; }

        // Relaciones
        public ICollection<Saga> Sagas { get; set; } = new List<Saga>();
        public ICollection<Character> Characters { get; set; } = new List<Character>();
        public ICollection<AnimeVideo> Videos { get; set; } = new List<AnimeVideo>();
        public ICollection<AnimeCategory> AnimeCategories { get; set; } = new List<AnimeCategory>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<ForumPost> ForumPosts { get; set; } = new List<ForumPost>();
    }
}
