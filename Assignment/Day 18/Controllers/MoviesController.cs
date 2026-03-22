using Microsoft.AspNetCore.Mvc;
using MovieCatalogApi.DTOs;
using MovieCatalogApi.Services;

namespace MovieCatalogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IDirectorService _directorService;

        public MoviesController(IMovieService movieService, IDirectorService directorService)
        {
            _movieService = movieService;
            _directorService = directorService;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        // GET: api/movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound(new { message = $"Movie with ID {id} not found" });
            }
            return Ok(movie);
        }

        // POST: api/movies
        [HttpPost]
        public async Task<ActionResult<MovieDto>> PostMovie(CreateMovieDto createMovieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if director exists
            var director = await _directorService.GetDirectorByIdAsync(createMovieDto.DirectorId);
            if (director == null)
            {
                return BadRequest(new { message = $"Director with ID {createMovieDto.DirectorId} does not exist" });
            }

            var movie = await _movieService.CreateMovieAsync(createMovieDto);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        // PUT: api/movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, CreateMovieDto updateMovieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if director exists
            var director = await _directorService.GetDirectorByIdAsync(updateMovieDto.DirectorId);
            if (director == null)
            {
                return BadRequest(new { message = $"Director with ID {updateMovieDto.DirectorId} does not exist" });
            }

            var success = await _movieService.UpdateMovieAsync(id, updateMovieDto);
            if (!success)
            {
                return NotFound(new { message = $"Movie with ID {id} not found" });
            }

            return NoContent();
        }

        // DELETE: api/movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var success = await _movieService.DeleteMovieAsync(id);
            if (!success)
            {
                return NotFound(new { message = $"Movie with ID {id} not found" });
            }

            return NoContent();
        }
    }
}
