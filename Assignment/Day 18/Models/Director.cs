using System.ComponentModel.DataAnnotations;

namespace MovieCatalogApi.Models
{
    public class Director
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
