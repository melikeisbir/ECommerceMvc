using ECommerceMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMvc.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
