using BookStoreApi.DTOs;

namespace BookStoreApi.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto?> GetBookByIdAsync(int id);
        Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);
        Task<bool> UpdateBookAsync(int id, CreateBookDto updateBookDto);
        Task<bool> DeleteBookAsync(int id);
    }
}
