using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieHouse.Infrastructure.Data.Identity;
using MovieHouse.Infrastructure.Data.Models;

using System.Reflection;

namespace MovieHouse.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovies> ActorsMovies { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MoviesGenres> MoviesGenres { get; set; }
        public DbSet<UserMovies> UsersMovies { get; set; }
        public DbSet<UserMoviesRating> UsersMoviesRatings { get; set; }
        public DbSet<UserMoviesReviews> UsersMoviesReviews { get; set; }
    }
}