using System.Xml.Linq;

namespace AnimeHubAPI.Domain.Entities
{
    public class Mangaka
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string Country { get; set; } = "Japón";
        public DateTime? BirthDate { get; set; }

        // Relaciones
        public ICollection<Anime> Animes { get; set; } = new List<Anime>();
    }
}
