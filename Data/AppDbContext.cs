using TechTask.Models;
using Microsoft.EntityFrameworkCore;

namespace TechTask.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}