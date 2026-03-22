using System.ComponentModel.DataAnnotations;

namespace MovieCatalogApi.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Director ID is required")]
        public int DirectorId { get; set; }

        public string? DirectorName { get; set; }

        public int ReleaseYear { get; set; }
    }

    public class CreateMovieDto
    {
        [Required(ErrorMessage = "Movie title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Director ID is required")]
        public int DirectorId { get; set; }

        public int ReleaseYear { get; set; }
    }
}
