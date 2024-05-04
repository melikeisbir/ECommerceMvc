using Microsoft.EntityFrameworkCore;

namespace ECommerceMvc.Entity
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
