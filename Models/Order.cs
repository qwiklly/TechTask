namespace TechTask.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; } = [];
        public DateTime OrderDate { get; set; }
    }
}

