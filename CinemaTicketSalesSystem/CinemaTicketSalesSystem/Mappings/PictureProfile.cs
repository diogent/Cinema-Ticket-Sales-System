using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesSystem.Models;
using CinemaTicketSalesSystem.ViewModels;

namespace CinemaTicketSalesSystem.Mappings
{
    public class PictureProfile : Profile
    {
        public PictureProfile ()
        {
            CreateMap<PicturesModel, PicturesViewModel>();
        }
    }
}