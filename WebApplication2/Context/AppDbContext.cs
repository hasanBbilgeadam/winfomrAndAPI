using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> p):base(p)
        {
                
        }
    }
}
