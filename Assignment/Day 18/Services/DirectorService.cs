using Microsoft.EntityFrameworkCore;
using MovieCatalogApi.Data;
using MovieCatalogApi.DTOs;
using MovieCatalogApi.Models;

namespace MovieCatalogApi.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly MovieCatalogDbContext _context;

        public DirectorService(MovieCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DirectorDto>> GetAllDirectorsAsync()
        {
            return await _context.Directors
                .Select(d => new DirectorDto { Id = d.Id, Name = d.Name })
                .ToListAsync();
        }

        public async Task<DirectorDto?> GetDirectorByIdAsync(int id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null) return null;

            return new DirectorDto { Id = director.Id, Name = director.Name };
        }

        public async Task<DirectorDto> CreateDirectorAsync(CreateDirectorDto createDirectorDto)
        {
            var director = new Director { Name = createDirectorDto.Name };
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();

            return new DirectorDto { Id = director.Id, Name = director.Name };
        }

        public async Task<bool> UpdateDirectorAsync(int id, CreateDirectorDto updateDirectorDto)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null) return false;

            director.Name = updateDirectorDto.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDirectorAsync(int id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null) return false;

            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByDirectorIdAsync(int directorId)
        {
            return await _context.Movies
                .Where(m => m.DirectorId == directorId)
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
    }
}
