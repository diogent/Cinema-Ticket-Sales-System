using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Interfaces;
using CinemaTicketSalesBusinessLogic.Models;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTicketSalesBusinessLogic.CRUD
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GenreService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        /// <summary>
        /// This method is mapping from Genre model to GenresModel
        /// </summary>
        public IEnumerable<GenresModel> GetGenresModel()
        {
            var genres = _db.Genres.ToList();
            var genresModels = genres.Select(m =>
            {
                var genresModel = _mapper.Map<Genre, GenresModel>(m);
                return genresModel;
            });

            return genresModels;
        }
    }
}
