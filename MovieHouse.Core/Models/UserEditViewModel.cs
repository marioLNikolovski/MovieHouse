using MovieHouse.Infrastructure.Data.Models;

namespace MovieHouse.Core.Models
{
    public class UserEditViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
    
    }
}
