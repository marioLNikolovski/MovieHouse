using MovieHouse.Core.Models;

namespace MovieHouse.Core.Contracts
{
    public interface IActorService
    {
        Task AddActor(string firstName, string lastName, string birthDate, string countryId, string cityId, string photo,int age, List<string> actedInIds);
        Task<bool> UpdateActor(EditActorViewModel model);
    }
}
