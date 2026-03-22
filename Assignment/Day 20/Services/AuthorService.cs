using Microsoft.EntityFrameworkCore;
using BookStoreApi.Data;
using BookStoreApi.DTOs;
using BookStoreApi.Models;

namespace BookStoreApi.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookStoreDbContext _context;

        public AuthorService(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            return await _context.Authors
                .Select(a => new AuthorDto { Id = a.Id, Name = a.Name })
                .ToListAsync();
        }

        public async Task<AuthorDto?> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return null;

            return new AuthorDto { Id = author.Id, Name = author.Name };
        }

        public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            var author = new Author { Name = createAuthorDto.Name };
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return new AuthorDto { Id = author.Id, Name = author.Name };
        }

        public async Task<bool> UpdateAuthorAsync(int id, CreateAuthorDto updateAuthorDto)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return false;

            author.Name = updateAuthorDto.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return false;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BookDto>> GetBooksByAuthorIdAsync(int authorId)
        {
            return await _context.Books
                .Where(b => b.AuthorId == authorId)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    AuthorName = b.Author != null ? b.Author.Name : null,
                    PublicationYear = b.PublicationYear
                })
                .ToListAsync();
        }
    }
}
