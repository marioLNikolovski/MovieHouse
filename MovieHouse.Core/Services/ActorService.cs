using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieHouse.Core.Contracts;
using MovieHouse.Core.Models;
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
        public async Task AddActor(string firstName, string lastName, string birthDate, string countryId, string cityId, string photo, int age, List<string> actedInIds)
        {
            if (String.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First Name name cannot be null or empty.");
            if (String.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last Name cannot be null or empty.");

            var country = repo.All<Country>().FirstOrDefault(x => x.Id == countryId);

            var city = repo.All<City>().FirstOrDefault(x => x.Id == cityId);

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

        public async Task<Tuple<List<Actor>, bool, int>> FindActorForCatalogAsync(string keyword, int page, int pageSize)
        {
            bool lastPage = true;

            var actors = await repo.All<Actor>().Where(actor => actor.FirstName.Contains(keyword)).ToListAsync();
            actors = actors.Skip((page - 1) * pageSize).ToList();
            var totalCount = actors.Count;
            var resultActors = actors.Take(pageSize).ToList();

            if (totalCount > pageSize)
            {
                lastPage = false;
            }

            return new Tuple<List<Actor>, bool, int>(resultActors, lastPage, totalCount);
        }

        public async Task<bool> UpdateActor(EditActorViewModel model)
        {
            bool result = false;
            var actor = await repo.GetByIdAsync<Actor>(model.Id);
            var data = repo.All<Movie>().ToList();

            var country = repo.All<Country>().FirstOrDefault(x => x.Id == model.BirthCountryId);

            var city = repo.All<City>().FirstOrDefault(x => x.Id == model.BirthCityId);
            //var viewActorMovies = data.Select(movie => new SelectListItem { Text = movie.Name, Value = movie.Id }).ToList();
            if (actor != null)
            {
                actor.FirstName = model.FirstName;
                actor.LastName = model.LastName;
                actor.BirthCountry = country;
                actor.BirthCity = city;
                actor.Age = model.Age;
                actor.Photo = model.Photo;
                actor.BirthDate = DateTime.ParseExact(model.BirthDate, "dd.mm.yyyy", CultureInfo.InvariantCulture);
              
                
                result = true;
            }

            var actedInMovies = model.ActedInIds.Select(movieId => new ActorMovies
            {
                Actor = actor,
                Movie = repo.All<Movie>().FirstOrDefault(x => x.Id == movieId),
            });
            await repo.AddRangeAsync<ActorMovies>(actedInMovies);
            await repo.SaveChangesAsync();
            return result;
        }
    }
}
