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
    public class UserMoviesConfiguration : IEntityTypeConfiguration<UserMovies>
    {
        public void Configure(EntityTypeBuilder<UserMovies> builder)
        {
            builder
               .HasOne(e => e.Movie)
               .WithMany(e => e.FavoritedBy)
               .HasForeignKey(e => e.MovieId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(e => e.ApplicationUser)
               .WithMany(e => e.FavoriteMovies)
               .HasForeignKey(e => e.ApplicationUserId).
               OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(e => new { e.ApplicationUserId, e.MovieId });
        }
    }
}
