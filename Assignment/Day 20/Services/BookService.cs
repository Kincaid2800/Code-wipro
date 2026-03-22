using Microsoft.EntityFrameworkCore;
using BookStoreApi.Data;
using BookStoreApi.DTOs;
using BookStoreApi.Models;

namespace BookStoreApi.Services
{
    public class BookService : IBookService
    {
        private readonly BookStoreDbContext _context;

        public BookService(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
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

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                AuthorName = book.Author != null ? book.Author.Name : null,
                PublicationYear = book.PublicationYear
            };
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            var book = new Book
            {
                Title = createBookDto.Title,
                AuthorId = createBookDto.AuthorId,
                PublicationYear = createBookDto.PublicationYear
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return await GetBookByIdAsync(book.Id) ?? new BookDto { Id = book.Id, Title = book.Title, AuthorId = book.AuthorId, PublicationYear = book.PublicationYear };
        }

        public async Task<bool> UpdateBookAsync(int id, CreateBookDto updateBookDto)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            book.Title = updateBookDto.Title;
            book.AuthorId = updateBookDto.AuthorId;
            book.PublicationYear = updateBookDto.PublicationYear;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
