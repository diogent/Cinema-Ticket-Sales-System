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
            CreateMap<MovieInfoModel, MovieViewModel>();
            CreateMap<CreateMovieViewModel, CreateMovieModel>();
            CreateMap<MovieModel, MoviesViewModel>();
        }
    }
}