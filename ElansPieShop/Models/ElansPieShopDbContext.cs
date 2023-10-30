using Microsoft.EntityFrameworkCore;

namespace ElansPieShop.Models
{
    public class ElansPieShopDbContext : DbContext // inherits from DbContext
    {
        public ElansPieShopDbContext(DbContextOptions<ElansPieShopDbContext> options) : base(options)// constructor
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }//property 
    }
}
