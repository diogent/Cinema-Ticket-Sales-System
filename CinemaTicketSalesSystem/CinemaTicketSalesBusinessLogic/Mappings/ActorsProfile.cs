using ApplicationDbMovies.Models;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;

namespace CinemaTicketSalesBusinessLogic.Mappings
{
    public class ActorsProfile : Profile
    {
        public ActorsProfile()
        {
            CreateMap<AddActorsModel, Actor>();
        }
    }
}
