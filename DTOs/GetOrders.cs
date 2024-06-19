using System.ComponentModel.DataAnnotations;
using TechTask.Models;

namespace TechTask.DTOs
{
    public class GetOrdersDTO
    {
        [Required]
        public int OrderId { get; set; } 

        [Required]
        public List<Product> Products { get; set; } = [];

        [Required]
        public DateTime OrderDate { get; set; }
    }
}