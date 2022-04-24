using MovieHouse.Core.Contracts;
using MovieHouse.Infrastructure.Data.Models;
using MovieHouse.Infrastructure.Data.Repositories;
using System.Globalization;

namespace MovieHouse.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IApplicationDbRepository repo;
        public MovieService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task AddMovie(string name, string releaseDate, string coverPhoto, string countryId, string directedById, string[] actorsIds, string[] genresIds)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name name cannot be null or empty.");
            if (String.IsNullOrWhiteSpace(releaseDate))
                throw new ArgumentException("Release Date cannot be null or empty.");

            var country = repo.All<Country>().FirstOrDefault(x => x.Id == countryId);

            var movie = new Movie()
            {
                Name = name,
                ReleaseDate = DateTime.ParseExact(releaseDate, "dd.mm.yyyy", CultureInfo.InvariantCulture),
                CoverPhoto = coverPhoto,
                Country = country,
                DirectedBy = directedById,
            };
            var moviesActors = actorsIds.Select(actorId => new ActorMovies
            {
                Actor = repo.All<Actor>().FirstOrDefault(x => x.Id == actorId),
                Movie = movie
            });

            var moviesGenres = genresIds.Select(genreId => new MoviesGenres
            {
                Movie = movie,
                Genre = repo.All<Genre>().FirstOrDefault(x => x.Id == genreId),
            });

            await repo.AddAsync<Movie>(movie);
            await repo.AddRangeAsync<ActorMovies>(moviesActors);
            await repo.AddRangeAsync<MoviesGenres>(moviesGenres);

            await repo.SaveChangesAsync();
        }
    }
}
