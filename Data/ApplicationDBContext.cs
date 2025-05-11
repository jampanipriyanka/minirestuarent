using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using minirestuarent.Models;

namespace minirestuarent.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<minirestuarent.Models.Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category{ Id=1, Name="Action", DisplayOrder = 1 },
                new Category{ Id=2, Name="SciFi", DisplayOrder = 2 },
                new Category{ Id=3, Name="Thriller", DisplayOrder = 3 }
            );
        }

    }
}