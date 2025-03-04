using Microsoft.EntityFrameworkCore;
using PokeLoginApi.Models;

namespace PokeLoginApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; } = default!;
    }
}
