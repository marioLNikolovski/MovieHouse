using Microsoft.EntityFrameworkCore;
using MovieHouse.Core.Contracts;
using MovieHouse.Core.Models;
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
        public async Task AddMovie(string name, string releaseDate, string coverPhoto, string countryId, string directedById, List<string> actorsIds, List<string> genresIds)
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

        public async Task<Movie> FindMovieByIdAsync(string id)
        {
            var movie = await repo.All<Movie>()
                         .Where(p => p.Id == id)
                         .Include(p=> p.Country)
                         .FirstOrDefaultAsync();

            if (movie == null)
            {
                throw new ArgumentNullException("Movie with given Id does not exist.");
            }
            return movie;
        }

        public async Task<Tuple<List<Movie>, bool, int>> FindMoviesForCatalogAsync(string keyword,int page, int pageSize)
        {
            bool lastPage = true;

            var movies = await repo.All<Movie>().Where(movie => movie.Name.Contains(keyword)).ToListAsync();
            movies = movies.Skip((page - 1) * pageSize).ToList();
            var totalCount = movies.Count;
            var resultMovies = movies.Take(pageSize).ToList();


            if (totalCount > pageSize)
            {
                lastPage = false;
            }

            return new Tuple<List<Movie>, bool, int>(resultMovies, lastPage, totalCount);
        }

        public async Task<bool> UpdateMovie(EditMovieViewModel model)
        {
            bool result = false;
            var movie = await repo.GetByIdAsync<Movie>(model.Id);
            var data = repo.All<Actor>().ToList();

            var country = repo.All<Country>().FirstOrDefault(x => x.Id == model.CountryId);

            if (movie != null)
            {
                movie.Name = model.Name;
                movie.DirectedBy = model.DirectedById;
                movie.Country = country;
                movie.CoverPhoto = model.CoverPhoto;
                movie.ReleaseDate = DateTime.ParseExact(model.ReleaseDate, "dd.mm.yyyy", CultureInfo.InvariantCulture);


                result = true;
            }

            var moviesActors = model.ActorsIds.Select(actorId => new ActorMovies
            {
                Actor = repo.All<Actor>().FirstOrDefault(x => x.Id == actorId),
                Movie = movie
            });

            var moviesGenres = model.GenresIds.Select(genreId => new MoviesGenres
            {
                Movie = movie,
                Genre = repo.All<Genre>().FirstOrDefault(x => x.Id == genreId),
            });

            await repo.AddRangeAsync<ActorMovies>(moviesActors);
            await repo.AddRangeAsync<MoviesGenres>(moviesGenres);

            await repo.SaveChangesAsync();

            return result;
        }
    }
}
