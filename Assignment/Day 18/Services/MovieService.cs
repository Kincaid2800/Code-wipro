using Microsoft.EntityFrameworkCore;
using MovieCatalogApi.Data;
using MovieCatalogApi.DTOs;
using MovieCatalogApi.Models;

namespace MovieCatalogApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieCatalogDbContext _context;

        public MovieService(MovieCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            return await _context.Movies
                .Include(m => m.Director)
                .Select(m => new MovieDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    DirectorId = m.DirectorId,
                    DirectorName = m.Director != null ? m.Director.Name : null,
                    ReleaseYear = m.ReleaseYear
                })
                .ToListAsync();
        }

        public async Task<MovieDto?> GetMovieByIdAsync(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Director)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null) return null;

            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                DirectorId = movie.DirectorId,
                DirectorName = movie.Director != null ? movie.Director.Name : null,
                ReleaseYear = movie.ReleaseYear
            };
        }

        public async Task<MovieDto> CreateMovieAsync(CreateMovieDto createMovieDto)
        {
            var movie = new Movie
            {
                Title = createMovieDto.Title,
                DirectorId = createMovieDto.DirectorId,
                ReleaseYear = createMovieDto.ReleaseYear
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            // Fetch again to include Director info
            return await GetMovieByIdAsync(movie.Id) ?? new MovieDto { Id = movie.Id, Title = movie.Title, DirectorId = movie.DirectorId, ReleaseYear = movie.ReleaseYear };
        }

        public async Task<bool> UpdateMovieAsync(int id, CreateMovieDto updateMovieDto)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return false;

            movie.Title = updateMovieDto.Title;
            movie.DirectorId = updateMovieDto.DirectorId;
            movie.ReleaseYear = updateMovieDto.ReleaseYear;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return false;

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
