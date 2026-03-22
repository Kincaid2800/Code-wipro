using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCatalogApi.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int DirectorId { get; set; }

        [ForeignKey("DirectorId")]
        public Director? Director { get; set; }

        public int ReleaseYear { get; set; }
    }
}
