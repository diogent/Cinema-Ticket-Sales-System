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
        public ICollection<GenresModel> Genres { get; set; }
        public ICollection<ProducersModel> Producers { get; set; }
        public ICollection<ActorsModel> Actors { get; set; }
        public ICollection<PicturesModel> Pictures { get; set; }
    }
}
