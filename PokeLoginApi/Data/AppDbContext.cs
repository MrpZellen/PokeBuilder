<<<<<<< HEAD
version https://git-lfs.github.com/spec/v1
oid sha256:27fa21d3b1c9316fa475247d2f6dde5913df9bee74cba52be7b27c2cb50dd35e
size 518
=======
﻿using Microsoft.EntityFrameworkCore;
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
>>>>>>> 9b4ef72 (fixed github)
