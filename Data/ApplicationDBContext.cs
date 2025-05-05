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

    }
}