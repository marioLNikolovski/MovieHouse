using MovieHouse.Infrastructure.Data.Identity;
using MovieHouse.Infrastructure.Data.Models;
using MovieHouse.Infrastructure.Data.Repositories;

namespace MovieHouse.Core.Models
{
    public class UserEditViewModel
    {
        private readonly IApplicationDbRepository repo;

        public UserEditViewModel(ApplicationUser user, IApplicationDbRepository _repo)
        {
            user.Id = Id;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.CountryId = Country;
            user.CityId = City;
            
            
        }

        public UserEditViewModel()
        {

        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public IEnumerable<Country> CountryList { get; set; } = new List<Country>();

    }
}
