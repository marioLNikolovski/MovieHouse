namespace MovieHouse.Core.Contracts
{
    public interface IActorService
    {
        Task AddActor(string firstName, string lastName, string birthDate, string countryId, string cityId, string photo,int age, string[] actedInIds);
    }
}
