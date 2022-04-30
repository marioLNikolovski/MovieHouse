using Microsoft.AspNetCore.Mvc;
using MovieHouse.Core.Contracts;
using MovieHouse.Core.Models;
using MovieHouse.Infrastructure.Data.Models;

namespace MovieHouse.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService actorService;
        public ActorController(IActorService _actorService)
        {
            actorService = _actorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ActorSearchResults(string keyword, string page, string pageSize)
        {
            Tuple<List<Actor>, bool, int> searchResults;
            var model = new ActorSearchViewModel()
            {
                Keyword = keyword == null ? "" : keyword,
                Searched = true,
                Page = int.Parse(page)
            };

            searchResults = await actorService.FindActorForCatalogAsync(model.Keyword, model.Page, int.Parse(pageSize));

            foreach (var actor in searchResults.Item1)
            {
                model.Actors.Add(new ActorViewModel(actor));
            }
            model.LastPage = searchResults.Item2;
            model.TotalCount = searchResults.Item3;
            model.ActorsCount = model.Actors.Count;
            return PartialView("_ActorSearchView", model);
        }
    }
}
