using CinemaTicketSalesBusinessLogic.Models;
using System.Collections.Generic;

namespace CinemaTicketSalesBusinessLogic.Interfaces
{
    public interface IGenreService
    {
        /// <summary>
        /// This method is mapping from Genre model to GenresModel
        /// </summary>
        IEnumerable<GenresModel> GetGenresModel();
    }
}
