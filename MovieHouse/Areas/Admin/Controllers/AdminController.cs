using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieHouse.Core.Constants;
using MovieHouse.Core.Contracts;

namespace MovieHouse.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountService accountService;

        [Area("Admin")]
        [Authorize(Roles = UserConstants.Roles.Admin)]
        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> ManageUsers()
        {
            var users = await accountService.GetUsers();
            return Ok(users);
        }
       
    }
}
