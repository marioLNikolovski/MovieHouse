using MovieHouse.Core.Contracts;
using MovieHouse.Infrastructure.Data.Models;
using MovieHouse.Infrastructure.Data.Repositories;
using System.Globalization;

namespace MovieHouse.Core.Services
{
    public class ActorService : IActorService
    {
        private readonly IApplicationDbRepository repo;

        public ActorService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task AddActor(string firstName, string lastName, string birthDate, string countryId, string cityId, string photo, int age, string[] actedInIds)
        {
            if (String.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First Name name cannot be null or empty.");
            if (String.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last Name cannot be null or empty.");

            var country = repo.All<Country>().FirstOrDefault(x => x.Name == countryId);

            var city = repo.All<City>().FirstOrDefault(x => x.Name == cityId);

            var actor = new Actor()
            {
               FirstName = firstName,
               LastName = lastName,
               BirthDate = DateTime.ParseExact(birthDate, "dd.mm.yyyy", CultureInfo.InvariantCulture),
               BirthCountry = country,
               BirthCity = city,
               Photo = "dsadas",
               Age = age,
               

            };

            var actedInMovies = actedInIds.Select(movieId => new ActorMovies
            {
                Actor = actor,
                Movie = repo.All<Movie>().FirstOrDefault(x => x.Id == movieId),
            });
           
            await repo.AddAsync<Actor>(actor);
            await repo.AddRangeAsync<ActorMovies>(actedInMovies);
           
            await repo.SaveChangesAsync();

           
        }
    }
}
