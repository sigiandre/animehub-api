using AnimeHubAPI.Domain.DTOs;
using AnimeHubAPI.Domain.Entities;
using AnimeHubAPI.Repositories.Interfaces;
using AnimeHubAPI.Services.Interfaces;

namespace AnimeHubAPI.Services.Implementations
{
    public class AnimeService : IAnimeService
    {
        private readonly IAnimeRepository _repo;
        public AnimeService(IAnimeRepository repo) 
        {
            _repo = repo;
        }

        public async Task<IEnumerable<AnimeDto>> GetAllAsync() => 
            (await _repo.GetAllAsync()).Select(MapToDto);

        public async Task<AnimeDto?> GetByIdAsync(int id) 
        { 
            var a = await _repo.GetByIdAsync(id); 
            return a == null ? null : MapToDto(a); 
        }

        public async Task<AnimeDto> CreateAsync(AnimeCreateDto dto)
        {
            var entity = new Anime
            {
                Title = dto.Title,
                Synopsis = dto.Synopsis,
                CoverImageUrl = dto.CoverImageUrl,
                BannerImageUrl = dto.BannerImageUrl,
                ReleaseYear = dto.ReleaseYear,
                Status = dto.Status,
                MangakaId = dto.MangakaId,
                StudioId = dto.StudioId
            };
            await _repo.AddAsync(entity);
            var created = await _repo.GetByIdAsync(entity.Id); // Para traer las navegaciones pobladas
            return MapToDto(created!);
        }

        private static AnimeDto MapToDto(Anime a) => new()
        {
            Id = a.Id,
            Title = a.Title,
            Synopsis = a.Synopsis,
            CoverImageUrl = a.CoverImageUrl,
            BannerImageUrl = a.BannerImageUrl,
            ReleaseYear = a.ReleaseYear,
            Status = a.Status,
            Mangaka = a.Mangaka == null ? null : new MangakaDto 
            { 
                Id = a.Mangaka.Id, 
                Name = a.Mangaka.Name, 
                Biography = a.Mangaka.Biography, 
                Country = a.Mangaka.Country,
                BirthDate = a.Mangaka.BirthDate 
            },
            Studio = a.Studio == null ? null : new StudioDto 
            { 
                Id = a.Studio.Id, 
                Name = a.Studio.Name, 
                Country = a.Studio.Country, 
                FoundedYear = a.Studio.FoundedYear 
            }
        };
    }
}