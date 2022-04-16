using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieHouse.Core.Contracts;
using MovieHouse.Infrastructure.Data.Models;
using MovieHouse.Infrastructure.Data.Repositories;
using MovieHouse.Models;

namespace MovieHouse.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IApplicationDbRepository repo;

        public AccountController(
            IAccountService _accountService,
            IApplicationDbRepository _repo
            )
        {
            accountService = _accountService;
            repo = _repo;
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



    }
}
