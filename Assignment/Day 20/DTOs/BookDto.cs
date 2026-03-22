using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author ID is required")]
        public int AuthorId { get; set; }

        public string? AuthorName { get; set; }

        public int PublicationYear { get; set; }
    }

    public class CreateBookDto
    {
        [Required(ErrorMessage = "Book title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author ID is required")]
        public int AuthorId { get; set; }

        public int PublicationYear { get; set; }
    }
}
