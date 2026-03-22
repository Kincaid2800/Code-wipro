using BookStoreApi.DTOs;

namespace BookStoreApi.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
        Task<AuthorDto?> GetAuthorByIdAsync(int id);
        Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto);
        Task<bool> UpdateAuthorAsync(int id, CreateAuthorDto updateAuthorDto);
        Task<bool> DeleteAuthorAsync(int id);
        Task<IEnumerable<BookDto>> GetBooksByAuthorIdAsync(int authorId);
    }
}
