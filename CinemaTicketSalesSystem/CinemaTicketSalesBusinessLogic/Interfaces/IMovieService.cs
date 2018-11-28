using System.Collections.Generic;
using ApplicationDbMovies.Models;
using CinemaTicketSalesBusinessLogic.Models;

namespace CinemaTicketSalesBusinessLogic.Interfaces
{
    public interface IMovieService
    {
        /// <summary>
        /// Using in HomeController for viewing Movies collection on the Main page.
        /// </summary> 
        IEnumerable<MovieInfoModel> GetMovies();

        /// <summary>
        /// Using for viewing description data of the selected movie.
        /// </summary>
        /// <param name="id">
        /// Using to find the relative data.
        /// </param>
        /// <returns></returns>
        LearnMoreMovieModel GetMovieDetails(int id);

        /// <summary>
        /// This method used to create a new Movie
        /// </summary>
        /// <param name="newMovieModel">
        /// Parameter from UI
        /// </param>
        void CreateMovie(CreateMovieModel newMovie, string path);
    }
}
