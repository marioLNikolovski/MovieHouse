using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHouse.Infrastructure.Data.Models
{
    public class Actor
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [RegularExpression(@"([A-Z][a-z]{1,36})([\\s\\\'-][A-Z][a-z]{1,36})*")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"([A-Z][a-z]{1,60})")]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public int Age { get; set; }

        public string Photo { get; set; }


        public string BirthCityId { get; set; }
      
        public City BirthCity { get; set; }


        public string BirthCountryId { get; set; }
      
        public Country BirthCountry { get; set; }

        public ICollection<ActorMovies> ActedIn { get; set; }
        

        public Actor()
        {
            ActedIn = new List<ActorMovies>();
           
        }
    }
}
