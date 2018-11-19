using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesSystem.Models;
using CinemaTicketSalesSystem.ViewModels;

namespace CinemaTicketSalesSystem.Mappings
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieModel, MovieViewModel>();
            CreateMap<CreateMovieViewModel, CreateMovieModel>();
        }
    }
}