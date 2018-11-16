using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSalesBusinessLogic.Models
{
    public class CreateMovieModel
    {        
        public string Name { get; set; }    
        public string Description { get; set; }
        public DateTime DateOfPremiere { get; set; }
        public string AgeRating { get; set; }
    }
}
