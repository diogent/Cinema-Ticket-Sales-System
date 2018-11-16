using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesSystem.Models;
using CinemaTicketSalesSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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