using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieHouse.Core.Constants;
using MovieHouse.Core.Contracts;
using MovieHouse.Core.Models;
using MovieHouse.Infrastructure.Data.Identity;
using MovieHouse.Infrastructure.Data.Repositories;


namespace MovieHouse.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IApplicationDbRepository repo;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(
            IAccountService _accountService,
            IApplicationDbRepository _repo,
            UserManager<ApplicationUser> _userManager
            )
        {
            accountService = _accountService;
            repo = _repo;
            userManager = _userManager;
        }
        public async Task<IActionResult> UserPage()
        {
            var userId = this.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var user = await accountService.FindUserByIdAsync(userId);
            var vm = new UserViewModel(user);
            vm.Initial = "userPage";
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

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
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


    }
}
