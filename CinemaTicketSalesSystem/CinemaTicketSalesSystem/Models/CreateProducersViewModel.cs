using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketSalesSystem.Models
{
    public class CreateProducersViewModel
    {
        [Required]
        public string FirstName { get; set; }        
        public string SecondName { get; set; }        
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
    }
}