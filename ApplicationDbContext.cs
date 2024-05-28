using Microsoft.EntityFrameworkCore;
using OnlineCinema.Models;
using System.Collections.Generic;

namespace OnlineCinema
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
          // Database.EnsureCreated();
        }
        public DbSet<Film> Films { get; set; }
    }
}
