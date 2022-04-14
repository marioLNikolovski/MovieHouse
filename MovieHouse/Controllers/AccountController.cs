using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using MovieHouse.Core.Contracts;
using MovieHouse.Models;

namespace MovieHouse.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        public async Task<IActionResult> UserPage()
        {
            var userId = this.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var user = await accountService.FindUserByIdAsync(userId);
            var vm = new UserViewModel(user);
            vm.Initial = "userPage";
            return View("UserProfile", vm);
        }

    }
}
