using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MoviesData.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfPremiere { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Producer> Producers { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }

        public Movie ()
        {
            Genres = new List<Genre>();
            Producers = new List<Producer>();
            Actors = new List<Actor>();
        }
       
    }
}