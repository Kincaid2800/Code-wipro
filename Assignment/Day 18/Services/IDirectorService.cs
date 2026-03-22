using MovieCatalogApi.DTOs;

namespace MovieCatalogApi.Services
{
    public interface IDirectorService
    {
        Task<IEnumerable<DirectorDto>> GetAllDirectorsAsync();
        Task<DirectorDto?> GetDirectorByIdAsync(int id);
        Task<DirectorDto> CreateDirectorAsync(CreateDirectorDto createDirectorDto);
        Task<bool> UpdateDirectorAsync(int id, CreateDirectorDto updateDirectorDto);
        Task<bool> DeleteDirectorAsync(int id);
        Task<IEnumerable<MovieDto>> GetMoviesByDirectorIdAsync(int directorId);
    }
}
