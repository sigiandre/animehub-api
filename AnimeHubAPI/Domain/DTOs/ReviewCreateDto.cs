using System.ComponentModel.DataAnnotations;

namespace AnimeHubAPI.Domain.DTOs
{
    public class ReviewCreateDto
    {
        public int AnimeId { get; set; }
        public int UserId { get; set; }
        [Range(1, 10)]
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
