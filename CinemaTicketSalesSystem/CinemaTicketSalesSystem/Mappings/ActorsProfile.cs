using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesSystem.Models;

namespace CinemaTicketSalesSystem.Mappings
{
    public class ActorsProfile : Profile
    {
        public ActorsProfile()
        {
            CreateMap<CreateActorsViewModel, AddActorsModel>();
            CreateMap<ActorsModel, ActorsViewModel>();
        }
    }
}