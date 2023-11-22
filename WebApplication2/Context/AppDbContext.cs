using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication2.Models;

namespace WebApplication2.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Car> Cars { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> p):base(p)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Car>().HasData(new Car[]
            {
                new(){ Id=1,Marka="BMW",Model="320",Fiyat=5000, ModelYil=2000,Renk="Siyah"},
                new(){ Id=2,Marka="BMW",Model="320",Fiyat=6000, ModelYil=2001,Renk="Siyah"},
                new(){ Id=3,Marka="BMW",Model="320",Fiyat=7000, ModelYil=2003,Renk="Beyaz"},

            });



        }
    }
}
