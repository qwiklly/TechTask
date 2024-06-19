using System.ComponentModel.DataAnnotations;

namespace TechTask.DTOs
{
    public class DeleteOrderDTO
    {
        [Required]
        public int Id { get; set; }
    }
}