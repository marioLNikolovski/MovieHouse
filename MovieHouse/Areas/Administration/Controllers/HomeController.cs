using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieHouse.Core.Constants;

namespace MovieHouse.Areas.Administration.Controllers
{

    [Authorize(Roles = UserConstants.Roles.Admin)]
    [Area("Administration")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
