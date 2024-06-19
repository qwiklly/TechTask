using System.ComponentModel.DataAnnotations;


namespace TechTask.DTOs
{
    public class GetProductsDTO
    {
        [Required]
        public int ProductId { get; set; }  

        [Required]
        public string? Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }
    }
}