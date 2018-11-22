using System;
using System.Collections.Generic;

namespace CinemaTicketSalesBusinessLogic.Models
{
    public class CreateMovieModel
    {        
        public string Name { get; set; }    
        public string Description { get; set; }
        public DateTime DateOfPremiere { get; set; }
        public string AgeRating { get; set; }        
        public IList<AddPictureModel> Pictures { get; set; }
        public IEnumerable<int> SelectedGenresIds { get; set; }
        public IEnumerable<int> SelectedProducersIds { get; set; }
        public IEnumerable<int> SelectedActorsIds { get; set; }


        public CreateMovieModel()
        {
            Pictures = new List<AddPictureModel>();
        }
    }
}
