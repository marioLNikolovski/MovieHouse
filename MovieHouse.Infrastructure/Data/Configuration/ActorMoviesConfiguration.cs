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
    public class ActorMoviesConfiguration : IEntityTypeConfiguration<ActorMovies>
    {
        public void Configure(EntityTypeBuilder<ActorMovies> builder)
        {
            builder
               .HasOne(e => e.Movie)
               .WithMany(e => e.Actors)
               .HasForeignKey(e => e.MovieId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(e => e.Actor)
               .WithMany(e => e.ActedIn)
               .HasForeignKey(e => e.ActorId).
               OnDelete(DeleteBehavior.Restrict);

            

            builder.HasKey(e => new { e.ActorId, e.MovieId });


        }
    }
}
