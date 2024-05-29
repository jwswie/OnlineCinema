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

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LikedFilm>()
                .HasKey(lf => new { lf.UserID, lf.FilmID });

            modelBuilder.Entity<LikedFilm>()
                .HasOne(lf => lf.User)
                .WithMany(u => u.LikedFilms)
                .HasForeignKey(lf => lf.UserID);

            modelBuilder.Entity<LikedFilm>()
                .HasOne(lf => lf.Film)
                .WithMany(f => f.LikedFilms)
                .HasForeignKey(lf => lf.FilmID);
        }*/

        public DbSet<Film> Films { get; set; }
       // public DbSet<User> Users { get; set; }
       // public DbSet<LikedFilm> LikedFilms { get; set; }
    }
}
