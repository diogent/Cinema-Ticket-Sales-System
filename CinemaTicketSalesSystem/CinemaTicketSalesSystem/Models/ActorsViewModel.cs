using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicketSalesSystem.Models
{
    public class ActorsViewModel
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