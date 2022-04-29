using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHouse.Core.Models
{
    public class MovieSearchViewModel
    {

        public MovieSearchViewModel()
        {
            Movies = new List<MovieViewModel>();
        }
        public bool Searched { get; set; }
        public int Page { get; set; }
        public string Keyword { get; set; }
        public bool LastPage { get; set; }

        public int TotalCount { get; set; }
        public List<MovieViewModel> Movies { get; set; }
    }
}
