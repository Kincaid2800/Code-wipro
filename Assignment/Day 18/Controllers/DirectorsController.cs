using Microsoft.AspNetCore.Mvc;
using MovieCatalogApi.DTOs;
using MovieCatalogApi.Services;

namespace MovieCatalogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        // GET: api/directors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorDto>>> GetDirectors()
        {
            var directors = await _directorService.GetAllDirectorsAsync();
            return Ok(directors);
        }

        // GET: api/directors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDto>> GetDirector(int id)
        {
            var director = await _directorService.GetDirectorByIdAsync(id);
            if (director == null)
            {
                return NotFound(new { message = $"Director with ID {id} not found" });
            }
            return Ok(director);
        }

        // POST: api/directors
        [HttpPost]
        public async Task<ActionResult<DirectorDto>> PostDirector(CreateDirectorDto createDirectorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var director = await _directorService.CreateDirectorAsync(createDirectorDto);
            return CreatedAtAction(nameof(GetDirector), new { id = director.Id }, director);
        }

        // PUT: api/directors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirector(int id, CreateDirectorDto updateDirectorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _directorService.UpdateDirectorAsync(id, updateDirectorDto);
            if (!success)
            {
                return NotFound(new { message = $"Director with ID {id} not found" });
            }

            return NoContent();
        }

        // DELETE: api/directors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            var success = await _directorService.DeleteDirectorAsync(id);
            if (!success)
            {
                return NotFound(new { message = $"Director with ID {id} not found" });
            }

            return NoContent();
        }

        // GET: api/directors/{directorId}/movies
        [HttpGet("{directorId}/movies")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMoviesByDirector(int directorId)
        {
            var director = await _directorService.GetDirectorByIdAsync(directorId);
            if (director == null)
            {
                return NotFound(new { message = $"Director with ID {directorId} not found" });
            }

            var movies = await _directorService.GetMoviesByDirectorIdAsync(directorId);
            return Ok(movies);
        }
    }
}
