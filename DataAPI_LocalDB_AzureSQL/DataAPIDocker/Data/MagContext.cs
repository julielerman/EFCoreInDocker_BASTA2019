using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataApiDocker;

namespace DataAPIDocker.Models
{
    public class MagContext : DbContext
    {
        public MagContext (DbContextOptions<MagContext> options)
            : base(options)
        {
        }

        public DbSet<Magazine> Magazine { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Magazine>().HasData
                (
                new Magazine { MagazineId = 1, Name = "BASTA! Magazine" },
                new Magazine { MagazineId = 2, Name = "Docker Magazine" },
                new Magazine { MagazineId = 3, Name = "EFCore Magazine" }
                );
        }
    }
}
