using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesSystem.Models;

namespace CinemaTicketSalesSystem.Mappings
{
    public class GenresProfile : Profile
    {
        public GenresProfile()
        {
            CreateMap<GenresModel, GenresViewModel>();
        }
    }
}