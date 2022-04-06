using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieHouse.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHouse.Infrastructure.Data.Configuration
{
    public class MoviesGenresConfiguration : IEntityTypeConfiguration<MoviesGenres>
    {
        public void Configure(EntityTypeBuilder<MoviesGenres> builder)
        {
            builder
              .HasOne(e => e.Movie)
              .WithMany(e => e.Genres)
              .HasForeignKey(e => e.MovieId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(e => e.Genre)
               .WithMany(e => e.Movies)
               .HasForeignKey(e => e.GenreId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(e => new { e.MovieId, e.GenreId });
        }
    }
}
