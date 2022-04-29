using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieHouse.Core.Models;
using MovieHouse.Infrastructure.Data.Models;
using MovieHouse.Infrastructure.Data.Repositories;

using System.Diagnostics;

namespace MovieHouse.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationDbRepository repo;

        public HomeController(ILogger<HomeController> logger, IApplicationDbRepository _repo)
        {
            _logger = logger;
            repo = _repo;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Catalog()
        {

            return View();
        }
    }
}