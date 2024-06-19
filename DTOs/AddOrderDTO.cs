using System.ComponentModel.DataAnnotations;
using TechTask.Models;

namespace TechTask.DTOs
{
    public class AddOrderDTO
    {
        [Required]
        public List<int> ProductIds { get; set; } = new List<int>();

        [Required]
        public DateTime OrderDate { get; set; }
    }
}