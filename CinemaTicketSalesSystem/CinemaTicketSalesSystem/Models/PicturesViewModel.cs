using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTicketSalesSystem.Models
{
    public class PicturesViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int MovieId { get; set; }
    }
}