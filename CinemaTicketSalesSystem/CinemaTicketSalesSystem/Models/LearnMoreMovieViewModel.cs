using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaTicketSalesSystem.Models
{
    public class LearnMoreMovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfPremiere { get; set; }

        public string AgeRating { get; set; }
        public virtual ICollection<GenresViewModel> Genres { get; set; }
        public virtual ICollection<ProducersViewModel> Producers { get; set; }
        public virtual ICollection<ActorsViewModel> Actors { get; set; }
        public virtual ICollection<PicturesViewModel> Pictures { get; set; }
    }
}