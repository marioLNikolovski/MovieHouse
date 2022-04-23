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

        public AdminController(IAccountService _accountService, IApplicationDbRepository _repo, IActorService _actorService)
        {
            accountService = _accountService;
            repo = _repo;
            actorService = _actorService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddActor()

        {
            var data = repo.All<Movie>().ToList();

            var viewActorMovies = data.Select(movie => new SelectListItem { Text = movie.Name, Value = movie.Id }).ToList();

            var actorViewModel = new AddActorViewModel();

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

           await actorService.AddActor(model.FirstName, model.LastName, model.BirthDate, model.BirthCountryId, model.BirthCityId, model.Photo, model.Age, model.ActedInIds);
            //string firstName, string lastName, string birthDate, string countryId, string cityId, string photo, int age, string[] actedInIds



            return View();
        }

    }
}
