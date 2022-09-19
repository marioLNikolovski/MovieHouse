using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieHouse.Core.Constants;
using MovieHouse.Core.Contracts;
using MovieHouse.Core.Models;
using MovieHouse.Infrastructure.Data.Identity;
using MovieHouse.Infrastructure.Data.Models;
using MovieHouse.Infrastructure.Data.Repositories;


namespace MovieHouse.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IApplicationDbRepository repo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(
            IAccountService _accountService,
            IApplicationDbRepository _repo,
            UserManager<ApplicationUser> _userManager,
            RoleManager<IdentityRole> _roleManager
            )
        {
            accountService = _accountService;
            repo = _repo;
            userManager = _userManager;
            roleManager = _roleManager;

        }
        public async Task<IActionResult> UserPage()
        {
            var userId = this.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var user = await accountService.FindUserByIdAsync(userId);
            var vm = new UserViewModel(user);
            vm.CountryList = await repo.All<Country>().ToListAsync();
            return View("UserProfile", vm);
        }
        public async Task<IActionResult> UserFavoriteMoviesPage()
        {
            var userId = this.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var user = await accountService.FindUserByIdAsync(userId);
            var vm = new UserViewModel(user);
            vm.Initial = "userFavoriteMoviesPage";
            return View("UserFavoriteMovieList", vm);
        }
        public async Task<IActionResult> UserRatedMoviesPage()
        {
            var userId = this.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var user = await accountService.FindUserByIdAsync(userId);
            var vm = new UserViewModel(user);
            vm.Initial = "UserRatedMoviesPage";
            return View("UserRatedMoviesList", vm);
        }
        public JsonResult LoadCity(string id)
        {
            var cities = repo.All<City>().Where(x => x.CountryId == id).ToList();
            return Json(new SelectList(cities, "Id", "Name"));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            model.CountryList = await repo.All<Country>().ToListAsync();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await accountService.UpdateUser(model))
            {
                ViewData[MessageConstants.SuccessMessage] = "Saved successfully!";
            }
            else
            {
                ViewData[MessageConstants.ErrorMessage] = "There was a problem!";
            }

            return View(model);
        }

        public async Task<IActionResult> FavoriteMovie(string movieId)
        {
            var userId = this.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            await accountService.FavoriteMovieAsync(userId, movieId);
            return Ok();
        }

      


    }
}
