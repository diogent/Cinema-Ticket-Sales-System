using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;

namespace CinemaTicketSalesBusinessLogic.Interfaces
{
    public interface IDbService
    {
        IEnumerable<MovieViewModel> GetMovieInfo();
        Movie GetMovieDescription(int id);
    }
}
