using System.Collections.Generic;
using System.Linq;
using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;
using CinemaTicketSalesBusinessLogic.Interfaces;

namespace CinemaTicketSalesBusinessLogic.Queries
{
    public class DbService : IDbService
    {
        private ApplicationDbContext _db;
        public DbService (ApplicationDbContext context)
        {
            _db = context;
        }       
        
        /// <summary>
        /// Using in HomeController for viewing Movies collection on the Main page.
        /// </summary>        
        public IEnumerable<MovieViewModel> GetMovieInfo()
        {
            return (from s in _db.Movies
                         join sa in _db.Pictures on s.Id equals sa.MovieId
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
        public Movie GetMovieDescription(int id)
        {
            var description = _db.Movies.Find(id);
            return description;
        }
    }
}
