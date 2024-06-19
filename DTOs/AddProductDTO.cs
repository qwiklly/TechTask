using System.ComponentModel.DataAnnotations;

namespace TechTask.DTOs
{
    public class AddProductDTO
    {
        [Required]
        public string? Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }
    }
}