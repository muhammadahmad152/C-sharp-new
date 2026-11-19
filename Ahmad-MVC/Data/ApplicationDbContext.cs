using Ahmad_MVC.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ahmad_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> users { get; set; }
    }
}