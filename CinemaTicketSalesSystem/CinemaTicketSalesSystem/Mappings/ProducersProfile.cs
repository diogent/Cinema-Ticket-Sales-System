using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesSystem.Models;

namespace CinemaTicketSalesSystem.Mappings
{
    public class ProducersProfile : Profile
    {
        public ProducersProfile()
        {
            CreateMap<EditProducersViewModel, AddProducersModel>();
        }
    }
}