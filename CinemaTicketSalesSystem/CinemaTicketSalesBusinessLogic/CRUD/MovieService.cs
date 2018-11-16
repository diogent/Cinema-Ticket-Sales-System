using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;
using CinemaTicketSalesBusinessLogic.Interfaces;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;
using System;

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
        public IEnumerable<MovieModel> GetMovies()
        {
            var movies = _db.Movies.Include(x => x.Pictures).ToList();
            var movieModels = movies.Select(m =>
                {
                    var movieModel = _mapper.Map<Movie, MovieModel>(m);
                    movieModel.Url = m.Pictures.FirstOrDefault()?.Url;
                    movieModel.MovieId = m.Id;
                    movieModel.MovieName = m.Name;
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
        public Movie GetMovieDetails(int id)
        {
            var description = _db.Movies.Find(id);
            return description;
        }

        /// <summary>
        /// This method used to create a new Movie
        /// </summary>
        /// <param name="newMovieModel">
        /// Parameter from UI
        /// </param>
        public void CreateMovie(CreateMovieModel newMovieModel, string path)
        {
            var newMovie = _mapper.Map<CreateMovieModel, Movie>(newMovieModel);
            var newPictureModel = new AddPictureModel { Url = path };
            var newPicture = _mapper.Map<AddPictureModel, Picture>(newPictureModel);
            newMovie.Pictures.Add(newPicture);
            _db.Movies.Add(newMovie);
            _db.SaveChanges();
        }
    }
}
