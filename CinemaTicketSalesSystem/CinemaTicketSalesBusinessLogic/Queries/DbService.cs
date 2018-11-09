using System.Collections.Generic;
using System.Linq;
using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;

namespace CinemaTicketSalesBusinessLogic.Queries
{
    public static class DbService
    {
        private static ApplicationDbContext db;

        /// <summary>
        /// Using in HomeController for viewing Movies collection on Main page.
        /// </summary>        
        public static IEnumerable<MovieViewModel> GetMovieInfo()
        {

            return (from s in db.Movies
                         join sa in db.Pictures on s.Id equals sa.MovieId
                         select new MovieViewModel
                         {
                             MovieId = s.Id,
                             MovieName = s.Name,
                             Description = s.Description,
                             Url = sa.Url
                         });
        }

        /// <summary>
        /// Using for viewing description data of the selected movie.
        /// </summary>
        /// <param name="id">
        /// Using to find the relative data.
        /// </param>
        /// <returns></returns>
        public static Movie GetMovieDescription(int id)
        {
            var description = db.Movies.Find(id);
            return description;
        }
    }
}
