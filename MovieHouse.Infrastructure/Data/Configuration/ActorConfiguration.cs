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
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder
               .HasOne(e => e.BirthCountry)
               .WithMany(e => e.ActorsBorned)
               .HasForeignKey(e => e.BirthCountryId)
               .OnDelete(DeleteBehavior.NoAction);

            builder
               .HasOne(e => e.BirthCity)
               .WithMany(e => e.ActorsBorned)
               .HasForeignKey(e => e.BirthCityId).
               OnDelete(DeleteBehavior.NoAction);



        }
    }
}
