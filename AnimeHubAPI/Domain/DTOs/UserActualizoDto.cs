using System.ComponentModel.DataAnnotations;

namespace AnimeHubAPI.Domain.DTOs
{
    public class UserActualizoDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        public string AvatarUrl { get; set; } = string.Empty;
    }
}
