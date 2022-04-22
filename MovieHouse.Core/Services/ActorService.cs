using MovieHouse.Core.Contracts;
using MovieHouse.Infrastructure.Data.Models;
using MovieHouse.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHouse.Core.Services
{
    public class ActorService : IActorService
    {
        private readonly IApplicationDbRepository repo;

        public ActorService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task AddActor(string firstName, string lastName, string birthDate, string countryName, string cityName, string photo, int age)
        {
            if (String.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First Name name cannot be null or empty.");
            if (String.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last Name cannot be null or empty.");

            var country = repo.All<Country>().Where(x => x.Name == countryName).First();

            var city = repo.All<City>().Where(x => x.Name == cityName).First();

            var actor = new Actor()
            {
               FirstName = firstName,
               LastName = lastName,
               BirthDate = DateTime.ParseExact(birthDate, "dd.mm.yyyy", CultureInfo.InvariantCulture),
               BirthCountry = country,
               BirthCity = city,
               Photo = "dsadas",
               Age = age


            };
            await repo.AddAsync<Actor>(actor);
           
            await repo.SaveChangesAsync();

           
        }
    }
}
