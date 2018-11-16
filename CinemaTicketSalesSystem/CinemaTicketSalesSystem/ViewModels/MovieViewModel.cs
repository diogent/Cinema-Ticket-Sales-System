using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTicketSalesSystem.ViewModels
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string Url { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
    }
}