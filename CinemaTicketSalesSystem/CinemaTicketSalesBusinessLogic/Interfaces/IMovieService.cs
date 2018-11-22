using System.Collections.Generic;
using ApplicationDbMovies.Models;
using CinemaTicketSalesBusinessLogic.Models;

namespace CinemaTicketSalesBusinessLogic.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<MovieInfoModel> GetMovies();
        LearnMoreMovieModel GetMovieDetails(int id);
        void CreateMovie(CreateMovieModel newMovie, string path);
    }
}
