using System;
using System.ComponentModel.DataAnnotations;
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
    }
}