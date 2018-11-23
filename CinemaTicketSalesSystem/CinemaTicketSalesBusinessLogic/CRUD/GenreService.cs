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
        
        public IEnumerable<GenresModel> GetGenresModel()
        {
            var genres = _db.Genres.ToList();
            var genresModels = _mapper.Map<IEnumerable<Genre>, IEnumerable<GenresModel>>(genres);
            return genresModels;
        }
    }
}
