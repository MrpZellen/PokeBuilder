<<<<<<< Updated upstream
version https://git-lfs.github.com/spec/v1
oid sha256:1e71d554c763075c4541f4ea2c6e245549a61ba289d926a9fb559182280a9009
size 696
=======
﻿using Microsoft.EntityFrameworkCore;
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
>>>>>>> Stashed changes
