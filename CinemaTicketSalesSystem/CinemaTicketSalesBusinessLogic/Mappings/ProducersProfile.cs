using ApplicationDbMovies.Models;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;

namespace CinemaTicketSalesBusinessLogic.Mappings
{
    public class ProducersProfile : Profile
    {
        public ProducersProfile()
        {
            CreateMap<AddProducersModel, Producer>();
            CreateMap<Producer, ProducersModel>();
        }
    }
}
