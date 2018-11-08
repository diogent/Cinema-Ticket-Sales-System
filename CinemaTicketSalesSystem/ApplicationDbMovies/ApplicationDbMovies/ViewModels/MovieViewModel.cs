using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDbMovies.Models
{
    public class MovieViewModel
    {
       public IEnumerable<Movie> Movies { get; set; }
       public IEnumerable<Picture> Pictures { get; set; }
    }
}
