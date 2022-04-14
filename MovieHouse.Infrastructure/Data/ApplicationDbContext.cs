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

            modelBuilder.Entity<Country>().HasData(
             new Country
             {
                 Id = "2df41905-09c5-4fda-8969-82198491b4b3",
                 Name = "Bulgaria"
             },
             new Country
             {
                 Id = "47d41ce9-16a8-4432-9db2-a00e0641069d",
                 Name = "Italy"
             },
               new Country
               {
                   Id = "ac8fe54f-9590-4634-80e1-61f99c423de4",
                   Name = "Germany"
               },
                 new Country
                 {
                     Id = "d05d0177-61c3-40ac-a106-25e3d950e68b",
                     Name = "France",

                 }
             );

            modelBuilder.Entity<City>().HasData(
             new City
             {
                 Id = "0085ed9d-dd87-4f6e-a3f8-07bd6a9fd234",
                 Name = "Sofia",
                 CountryId = "2df41905-09c5-4fda-8969-82198491b4b3"
             },
             new City
             {
                 Id = "00be197c-e96d-448e-b6b0-95e9561b6f1e",
                 Name = "Rome",
                 CountryId = "47d41ce9-16a8-4432-9db2-a00e0641069d"
             },
               new City
               {
                   Id = "25a950ad-9e91-44ba-a3e3-a35ff430afcf",
                   Name = "Berlin",
                   CountryId = "ac8fe54f-9590-4634-80e1-61f99c423de4"
               },
                 new City
                 {
                     Id = "3a2add9b-844c-4415-82f3-737835f2ebe6",
                     Name = "Paris",
                     CountryId = "d05d0177-61c3-40ac-a106-25e3d950e68b"
                 }
             );



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