﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
            modelBuilder.Entity<Genre>().HasData(
            new Genre
            {
                Id = "36ac357b-18ef-4fd2-83cc-c7be47422aa1",
                Name = "Action",
              
            },
            new Genre
            {
                Id = "f5039649-7040-42c3-8d4e-41f303808d47",
                Name = "Comedy",
               
            },
              new Genre
              {
                  Id = "76d9b9a6-9f19-4faa-8f3f-61601ad544b6",
                  Name = "Drama",
                
              },
                new Genre
                {
                    Id = "86a5b294-6326-46ff-970a-b49ca945df3c",
                    Name = "Horror",
                    
                },
                new Genre
                {
                    Id = "5598e6a3-555d-4b45-8b71-fee892d70c8c",
                    Name = "Fantasy",

                },
                 new Genre
                 {
                     Id = "4c0cc434-a39d-4c8d-a0ad-7ebf39e8d069",
                     Name = "Romance",

                 },
                  new Genre
                  {
                      Id = "261ce8fc-693f-4818-af77-f2a920bf3b8f",
                      Name = "Thriller",

                  },
                   new Genre
                   {
                       Id = "b07e9e0e-8883-4f40-9e87-b2ac19fd5cd0",
                       Name = "Science Fiction",

                   },
                    new Genre
                    {
                        Id = "fc7a2aa4-98b8-42de-9cf3-ec915a6ddaf2",
                        Name = "Western",

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