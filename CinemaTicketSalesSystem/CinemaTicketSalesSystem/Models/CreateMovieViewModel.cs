using CinemaTicketSalesSystem.Controllers;
using CinemaTicketSalesSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CinemaTicketSalesSystem.Models
{
    public class CreateMovieViewModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfPremiere { get; set; }

        [Required]
        [StringLength(3)]
        public string AgeRating { get; set; }
        
        [NotMapped]
        public IEnumerable<GenresViewModel> Genres { get; set; }
        
        public IEnumerable<int> SelectedGenresIds { get; set; }

        [NotMapped]
        public IEnumerable<ProducersViewModel> Producers { get; set; }
        
        public IEnumerable<int> SelectedProducersIds { get; set; }

        [NotMapped]
        public IEnumerable<ActorsViewModel> Actors { get; set; }
        
        public IEnumerable<int> SelectedActorsIds { get; set; }
    }
}