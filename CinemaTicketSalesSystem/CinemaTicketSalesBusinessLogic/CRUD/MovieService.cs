using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;
using CinemaTicketSalesBusinessLogic.Interfaces;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;

namespace CinemaTicketSalesBusinessLogic.Queries
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public MovieService(ApplicationDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Using in HomeController for viewing Movies collection on the Main page.
        /// </summary>        
        public IEnumerable<MovieInfoModel> GetMovies()
        {
            var movies = _db.Movies.Include(x => x.Pictures).ToList();
            var movieModels = movies.Select(m =>
                {
                    var movieModel = _mapper.Map<Movie, MovieInfoModel>(m);
                    movieModel.Url = m.Pictures.FirstOrDefault()?.Url;
                    return movieModel;
                });
            return movieModels;
        }

        /// <summary>
        /// Using for viewing description data of the selected movie.
        /// </summary>
        /// <param name="id">
        /// Using to find the relative data.
        /// </param>
        /// <returns></returns>
        public LearnMoreMovieModel GetMovieDetails(int id)
        {
            var description = _db.Movies.Find(id);
            var learnMoreMovie = _mapper.Map<Movie, LearnMoreMovieModel>(description);
            return learnMoreMovie;
        }

        /// <summary>
        /// This method used to create a new Movie
        /// </summary>
        /// <param name="newMovieModel">
        /// Parameter from UI
        /// </param>
        public void CreateMovie(CreateMovieModel newMovieModel, string path)
        {
            var producerIds = newMovieModel.SelectedProducersIds;
            var genresIds = newMovieModel.SelectedGenresIds;
            var actorsIds = newMovieModel.SelectedActorsIds;
            var newMovie = _mapper.Map<CreateMovieModel, Movie>(newMovieModel);
            var newPictureModel = new AddPictureModel { Url = path };
            var newPicture = _mapper.Map<AddPictureModel, Picture>(newPictureModel);
            newMovie.Pictures.Add(newPicture);
            foreach (var p in _db.Producers.Where(x => producerIds.Contains(x.Id)))
            {
                newMovie.Producers.Add(p);
            }

            foreach (var g in _db.Genres.Where(x => genresIds.Contains(x.Id)))
            {
                newMovie.Genres.Add(g);
            }

            foreach (var a in _db.Actors.Where(x => actorsIds.Contains(x.Id)))
            {
                newMovie.Actors.Add(a);
            }
            _db.Movies.Add(newMovie);                   
            _db.SaveChanges();
        }      
    }
}
