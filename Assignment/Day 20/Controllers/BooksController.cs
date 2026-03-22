using Microsoft.AspNetCore.Mvc;
using BookStoreApi.DTOs;
using BookStoreApi.Services;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BooksController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound(new { message = $"Book with ID {id} not found" });
            }
            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<BookDto>> PostBook(CreateBookDto createBookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if author exists
            var author = await _authorService.GetAuthorByIdAsync(createBookDto.AuthorId);
            if (author == null)
            {
                return BadRequest(new { message = $"Author with ID {createBookDto.AuthorId} does not exist" });
            }

            var book = await _bookService.CreateBookAsync(createBookDto);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, CreateBookDto updateBookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if author exists
            var author = await _authorService.GetAuthorByIdAsync(updateBookDto.AuthorId);
            if (author == null)
            {
                return BadRequest(new { message = $"Author with ID {updateBookDto.AuthorId} does not exist" });
            }

            var success = await _bookService.UpdateBookAsync(id, updateBookDto);
            if (!success)
            {
                return NotFound(new { message = $"Book with ID {id} not found" });
            }

            return NoContent();
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var success = await _bookService.DeleteBookAsync(id);
            if (!success)
            {
                return NotFound(new { message = $"Book with ID {id} not found" });
            }

            return NoContent();
        }
    }
}
