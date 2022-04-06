using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHouse.Infrastructure.Data.Models
{
    public class Genre
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public ICollection<MoviesGenres> Movies { get; set; }

        public Genre()
        {
            Movies = new List<MoviesGenres>();
        }
    }
}
