using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSalesBusinessLogic.Models
{
    public class LearnMoreMovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfPremiere { get; set; }
        public string AgeRating { get; set; }
        public virtual ICollection<GenresModel> Genres { get; set; }
        public virtual ICollection<ProducersModel> Producers { get; set; }
        public virtual ICollection<ActorsModel> Actors { get; set; }
        public virtual ICollection<PicturesModel> Pictures { get; set; }
    }
}
