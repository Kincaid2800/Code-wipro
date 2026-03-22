using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        public string Name { get; set; } = string.Empty;
    }

    public class CreateAuthorDto
    {
        [Required(ErrorMessage = "Author name is required")]
        public string Name { get; set; } = string.Empty;
    }
}
