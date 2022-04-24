using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieHouse.Areas.Administration.Models;
using MovieHouse.Core.Constants;
using MovieHouse.Core.Contracts;
using MovieHouse.Infrastructure.Data.Models;
using MovieHouse.Infrastructure.Data.Repositories;


namespace MovieHouse.Areas.Administration.Controllers
{

    [Authorize(Roles = UserConstants.Roles.Admin)]
    //[Area("Administration")]
    public class AdminController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IApplicationDbRepository repo;
        private readonly IActorService actorService;
        private readonly IMovieService movieService;

        public AdminController(IAccountService _accountService, IApplicationDbRepository _repo, IActorService _actorService, IMovieService _movieService)
        {
            accountService = _accountService;
            repo = _repo;
            actorService = _actorService;
            movieService = _movieService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult LoadCity(string id)
        {
            var cities = repo.All<City>().Where(x => x.CountryId == id).ToList();
            return Json(new SelectList(cities, "Id", "Name"));
        }
        public IActionResult AddActor()

        {
            var data = repo.All<Movie>().ToList();

            var viewActorMovies = data.Select(movie => new SelectListItem { Text = movie.Name, Value = movie.Id }).ToList();


            var actorViewModel = new AddActorViewModel();

            actorViewModel.CountryList = repo.All<Country>().ToList();

            actorViewModel.ActedIn = viewActorMovies;
           

            return View(actorViewModel);
            
        }

        [HttpPost]
        public async Task<IActionResult> AddActor(AddActorViewModel model)
        {

            if (!this.ModelState.IsValid)
            {
                return View("AddActor", model);

            }

            model.CountryList = repo.All<Country>().ToList();

           await actorService.AddActor(model.FirstName, model.LastName, model.BirthDate, model.BirthCountryId, model.BirthCityId, model.Photo, model.Age, model.ActedInIds);
            



            return View(model);
        }
        public IActionResult AddMovie()
        {
            var actorData = repo.All<Actor>().ToList();

            var genreData = repo.All<Genre>().ToList();

            var viewMoviesActors = actorData.Select(actor => new SelectListItem { Text = $"{actor.FirstName} {actor.LastName}", Value = actor.Id }).ToList();

            var viewMoviesGenres = genreData.Select(genre => new SelectListItem { Text = genre.Name, Value = genre.Id }).ToList();


            var movieViewModel = new AddMovieViewModel();

            movieViewModel.CountryList = repo.All<Country>().ToList();

            movieViewModel.Actors = viewMoviesActors;
            movieViewModel.Genres = viewMoviesGenres;
            


            return View(movieViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View("AddMovie", model);

            }
            model.CountryList = repo.All<Country>().ToList();

            await movieService.AddMovie(model.Name, model.ReleaseDate, model.CoverPhoto, model.CountryId, model.DirectedById, model.ActorsIds, model.GenresIds);

            return View(model);
        }

    }
}
