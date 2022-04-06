using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHouse.Infrastructure.Data.Models
{
    public class ActorMovies
    {
        public string ActorId { get; set; }
        [ForeignKey(nameof(ActorId))]
        public Actor Actor { get; set; }

        public string MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }
    }
}
