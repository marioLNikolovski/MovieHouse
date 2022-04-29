using Microsoft.AspNetCore.Mvc;

namespace MovieHouse.Controllers
{
    public class ActorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
