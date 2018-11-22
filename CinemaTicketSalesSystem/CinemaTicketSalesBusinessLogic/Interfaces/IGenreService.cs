using CinemaTicketSalesBusinessLogic.Models;
using System.Collections.Generic;

namespace CinemaTicketSalesBusinessLogic.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<GenresModel> GetGenresModel();
    }
}
