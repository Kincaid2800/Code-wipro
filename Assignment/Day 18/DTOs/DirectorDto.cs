using System.ComponentModel.DataAnnotations;

namespace MovieCatalogApi.DTOs
{
    public class DirectorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Director name is required")]
        public string Name { get; set; } = string.Empty;
    }

    public class CreateDirectorDto
    {
        [Required(ErrorMessage = "Director name is required")]
        public string Name { get; set; } = string.Empty;
    }
}
