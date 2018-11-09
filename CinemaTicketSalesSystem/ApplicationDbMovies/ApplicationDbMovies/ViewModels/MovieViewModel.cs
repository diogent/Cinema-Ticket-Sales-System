using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDbMovies.Models
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string Url { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
    }
}
