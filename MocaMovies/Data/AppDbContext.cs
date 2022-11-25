using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MocaMovies.Models;

namespace MocaMovies.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);


            base.OnModelCreating(modelBuilder);

            ////// Rating many to many
            //modelBuilder.Entity<Rating>().HasKey(am => new
            //{
            //    am.UserId,
            //    am.MovieId
            //});
            //modelBuilder.Entity<Rating>().HasOne(m => m.Movie).WithMany(am => am.RatingMovies).HasForeignKey(m => m.MovieId);

            //modelBuilder.Entity<Rating>().HasOne(m => m.User).WithMany(am => am.RatingMovies).HasForeignKey(m => m.UserId);


            //base.OnModelCreating(modelBuilder);

            ////// Total Movie Rating 
            //modelBuilder.Entity<Movie_Rate>().HasKey(am => new
            //{
            //    am.MovieId,
            //    am.TotalRate
            //});
            //modelBuilder.Entity<Movie_Rate>().HasOne(m => m.Movie).WithMany(am => am.Movies_Rates).HasForeignKey(m => m.MovieId);

            //modelBuilder.Entity<Movie_Rate>().HasOne(m => m.TotalRate).WithMany(am => am.Movies_Rates).HasForeignKey(m => m.UserId);


            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Producer> Producers { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Movie_Rate> Movies_Rates { get; set; }

        public DbSet<RatingByUser> RatingMoviesByUsers { get; set; }

        public DbSet<MovieVideo> movieVideos { get; set; }

    }
}
