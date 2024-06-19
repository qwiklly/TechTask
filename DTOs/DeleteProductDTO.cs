using System.ComponentModel.DataAnnotations;

namespace TechTask.DTOs
{
    public class DeleteProductDTO
    {
        [Required]
        public int Id { get; set; }
    }
}


