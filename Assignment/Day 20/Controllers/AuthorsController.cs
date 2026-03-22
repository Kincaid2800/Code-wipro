using Microsoft.AspNetCore.Mvc;
using BookStoreApi.DTOs;
using BookStoreApi.Services;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        // GET: api/authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound(new { message = $"Author with ID {id} not found" });
            }
            return Ok(author);
        }

        // POST: api/authors
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> PostAuthor(CreateAuthorDto createAuthorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = await _authorService.CreateAuthorAsync(createAuthorDto);
            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        // PUT: api/authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, CreateAuthorDto updateAuthorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _authorService.UpdateAuthorAsync(id, updateAuthorDto);
            if (!success)
            {
                return NotFound(new { message = $"Author with ID {id} not found" });
            }

            return NoContent();
        }

        // DELETE: api/authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var success = await _authorService.DeleteAuthorAsync(id);
            if (!success)
            {
                return NotFound(new { message = $"Author with ID {id} not found" });
            }

            return NoContent();
        }

        // GET: api/authors/{authorId}/books
        [HttpGet("{authorId}/books")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByAuthor(int authorId)
        {
            var author = await _authorService.GetAuthorByIdAsync(authorId);
            if (author == null)
            {
                return NotFound(new { message = $"Author with ID {authorId} not found" });
            }

            var books = await _authorService.GetBooksByAuthorIdAsync(authorId);
            return Ok(books);
        }
    }
}
