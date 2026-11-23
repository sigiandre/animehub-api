using AnimeHubAPI.Domain.DTOs;

namespace AnimeHubAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthResponseDto> RegisterAsync(UserRegistroDto dto);
        Task<AuthResponseDto?> LoginAsync(UserLoginDto dto);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, UserActualizoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
