using FrontTest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontTest.Data
{
    public class FrontTestContext : DbContext
    {
        public DbSet<AppUser> ApplicationUsers { get; set; } = null!;

        public FrontTestContext(DbContextOptions<FrontTestContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
