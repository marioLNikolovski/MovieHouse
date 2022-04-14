using MovieHouse.Infrastructure.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieHouse.Infrastructure.Data.Models
{
    public class City
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(90)]
        public string Name { get; set; }

        public string CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }

        public ICollection<ApplicationUser> UserBorned { get; set; }
        public ICollection<Actor> ActorsBorned { get; set; }

        public City()
        {
            UserBorned = new List<ApplicationUser>();
            ActorsBorned = new List<Actor>();
        }
    }
}
