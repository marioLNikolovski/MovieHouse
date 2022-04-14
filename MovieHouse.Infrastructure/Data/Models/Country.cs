using MovieHouse.Infrastructure.Data.Identity;
using System.ComponentModel.DataAnnotations;

namespace MovieHouse.Infrastructure.Data.Models
{
    public class Country
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
        public ICollection<Movie> Movies { get; set; }

        public ICollection<ApplicationUser> UsersBorned { get; set; }
        public ICollection<Actor> ActorsBorned { get; set; }

        public Country()
        {
            Cities = new List<City>();
            UsersBorned = new List<ApplicationUser>();
            ActorsBorned = new List<Actor>();
            Movies = new List<Movie>();
        }
    }
}
