using Microsoft.AspNetCore.Mvc;
using MovieHouse.Core.Contracts;
using MovieHouse.Core.Models;
using MovieHouse.Infrastructure.Data.Models;

namespace MovieHouse.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService _movieService)
        {
            movieService = _movieService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> MovieSearchResults(string keyword,string page,string pageSize)
        {
            Tuple<List<Movie>, bool, int> searchResults;
            var model = new MovieSearchViewModel()
            {
                Keyword = keyword == null ? "" : keyword,
                Searched = true,
                Page = int.Parse(page)
            };
          
            searchResults = await movieService.FindMoviesForCatalogAsync(model.Keyword, model.Page, int.Parse(pageSize));

            foreach (var movie in searchResults.Item1)
            {
                model.Movies.Add(new MovieViewModel(movie));
            }
            model.LastPage = searchResults.Item2;
            model.TotalCount = searchResults.Item3;
            model.MoviesCount = model.Movies.Count;
            return PartialView("_MovieSearchView", model);
        }
    }
}
