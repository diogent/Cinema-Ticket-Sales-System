using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesData.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        
        public Genre()
        {
            Movies = new List<Movie>();
        }
    }
}