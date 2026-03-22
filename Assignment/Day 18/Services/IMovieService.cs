using MovieCatalogApi.DTOs;

namespace MovieCatalogApi.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<MovieDto?> GetMovieByIdAsync(int id);
        Task<MovieDto> CreateMovieAsync(CreateMovieDto createMovieDto);
        Task<bool> UpdateMovieAsync(int id, CreateMovieDto updateMovieDto);
        Task<bool> DeleteMovieAsync(int id);
    }
}
