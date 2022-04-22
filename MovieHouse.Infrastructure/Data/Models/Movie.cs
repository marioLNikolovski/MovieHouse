using System.ComponentModel.DataAnnotations;

namespace MovieHouse.Infrastructure.Data.Models
{
    public class Movie
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }


        public string? CoverPhoto { get; set; }


        public string CountryId { get; set; }
        
        public Country Country { get; set; }

        public ICollection<MoviesGenres> Genres { get; set; }
        public ICollection<ActorMovies> Actors { get; set; }
        public ICollection<UserMovies> FavoritedBy { get; set; }
        public ICollection<UserMoviesReviews> Reviews { get; set; }
        public ICollection<UserMoviesRating> Ratings { get; set; }

        public Movie()
        {
            Genres = new List<MoviesGenres>();
            Actors = new List<ActorMovies>();
            FavoritedBy = new List<UserMovies>();
            Reviews = new List<UserMoviesReviews>();
            Ratings = new List<UserMoviesRating>();
        }
    }
}
