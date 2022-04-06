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
    public class UserMoviesRatingConfiguration : IEntityTypeConfiguration<UserMoviesRating>
    {
        public void Configure(EntityTypeBuilder<UserMoviesRating> builder)
        {
            builder
               .HasOne(e => e.Movie)
               .WithMany(e => e.Ratings)
               .HasForeignKey(e => e.MovieId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(e => e.ApplicationUser)
               .WithMany(e => e.UserMoviesRating)
               .HasForeignKey(e => e.ApplicationUserId).
               OnDelete(DeleteBehavior.Restrict);


            builder.HasKey(e => new { e.ApplicationUserId, e.MovieId });
        }
    }
}
