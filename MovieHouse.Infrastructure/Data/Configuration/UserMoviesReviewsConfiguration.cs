using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieHouse.Infrastructure.Data.Models;

namespace MovieHouse.Infrastructure.Data.Configuration
{
    public class UserMoviesReviewsConfiguration : IEntityTypeConfiguration<UserMoviesReviews>
    {
        public void Configure(EntityTypeBuilder<UserMoviesReviews> builder)
        {
            builder
              .HasOne(e => e.Movie)
              .WithMany(e => e.Reviews)
              .HasForeignKey(e => e.MovieId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(e => e.ApplicationUser)
               .WithMany(e => e.MoviesReviews)
               .HasForeignKey(e => e.ApplicationUserId).
               OnDelete(DeleteBehavior.Restrict);


            builder.HasKey(e => new { e.ApplicationUserId, e.MovieId });
        }
    }
}
