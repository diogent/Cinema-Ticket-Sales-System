using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTicketSalesSystem.Models
{
    public class ActorsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}