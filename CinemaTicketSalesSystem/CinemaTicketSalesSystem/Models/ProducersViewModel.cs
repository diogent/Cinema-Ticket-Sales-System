using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaTicketSalesSystem.Models
{
    public class ProducersViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";            
    }
}