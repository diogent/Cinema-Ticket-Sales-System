using ApplicationDbMovies.Models;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;

namespace CinemaTicketSalesBusinessLogic.Mappings
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieModel>();
        }
    }
}
