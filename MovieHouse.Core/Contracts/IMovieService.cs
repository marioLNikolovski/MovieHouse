using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHouse.Core.Contracts
{
    public interface IMovieService
    {
        Task AddMovie(string name, string releaseDate, string coverPhoto, string countryId, string directedById, string[] actorsIds, string[] genresIds);
    }
}
