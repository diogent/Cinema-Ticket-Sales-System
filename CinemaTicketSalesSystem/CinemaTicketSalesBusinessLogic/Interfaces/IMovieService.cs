using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;
using CinemaTicketSalesBusinessLogic.Models;

namespace CinemaTicketSalesBusinessLogic.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<MovieModel> GetMovies();
        Movie GetMovieDetails(int id);
        void CreateMovie(CreateMovieModel newMovie);
    }
}
