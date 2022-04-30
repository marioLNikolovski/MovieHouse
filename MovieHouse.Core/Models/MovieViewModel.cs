using MovieHouse.Infrastructure.Data.Models;
using System.Globalization;

namespace MovieHouse.Core.Models
{
    public class MovieViewModel
    {
        public MovieViewModel(Movie movie)
        {
            Name= movie.Name;   
            ReleaseDate = movie.ReleaseDate.ToString();
            CoverPhoto = "~/images/" + movie.CoverPhoto;
            CountryId = movie.CountryId;
            DirectedBy = movie.DirectedBy;
            Id = movie.Id;
            
        }
        public MovieViewModel()
        {

        }

        public string Id { get; set; }

        public string Name { get; set; }

        
        public string ReleaseDate { get; set; }


        public string? CoverPhoto { get; set; }

       
        public string CountryId { get; set; }

      
        public string? DirectedBy { get; set; }

        public ICollection<ActorMovies> Actors { get; set; }


    }
}
