using MovieHouse.Core.Models;
using MovieHouse.Infrastructure.Data.Models;

namespace MovieHouse.Core.Contracts
{
    public interface IActorService
    {
        Task AddActor(string firstName, string lastName, string birthDate, string countryId, string cityId, string photo,int age, List<string> actedInIds);
        Task<bool> UpdateActor(EditActorViewModel model);
        Task<Tuple<List<Actor>, bool, int>> FindActorForCatalogAsync(string keyword, int page, int pageSize);
        Task<Actor> FindActorByIdAsync(string id);
    }
}
