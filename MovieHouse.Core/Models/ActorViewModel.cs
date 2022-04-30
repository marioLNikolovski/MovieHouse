using MovieHouse.Infrastructure.Data.Models;

namespace MovieHouse.Core.Models
{
    public class ActorViewModel
    {
        public ActorViewModel(Actor actor)
        {
            FirstName = actor.FirstName;
            LastName = actor.LastName;
            BirthDate = actor.BirthDate.ToString();
            Age = actor.Age;
            Photo = "~/images/" + actor.Photo;
            BirthCountryId = actor.BirthCountryId;
            BirthCityId = actor.BirthCityId;
        }
        public ActorViewModel()
        {

        }
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

       
        public string BirthDate { get; set; }

       
        public int Age { get; set; }

        public string Photo { get; set; }


        public string BirthCityId { get; set; }

        public string BirthCountryId { get; set; }

        
    }
}
