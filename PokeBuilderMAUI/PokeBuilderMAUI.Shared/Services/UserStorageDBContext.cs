using Microsoft.EntityFrameworkCore;
using PokeBuilderMAUI.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace PokeBuilderMAUI.Shared.Services
{
    public class UserStorageDBContext : DbContext
    {
       public DbSet<User> Users { get; init; }
       public UserStorageDBContext(DbContextOptions<UserStorageDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>();
        }
    }
}
