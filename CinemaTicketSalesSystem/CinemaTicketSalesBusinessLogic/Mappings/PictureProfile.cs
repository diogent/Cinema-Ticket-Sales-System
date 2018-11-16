using ApplicationDbMovies.Models;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;

namespace CinemaTicketSalesBusinessLogic.Mappings
{
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {
            CreateMap<AddPictureModel, Picture>();
        }
    }
}
