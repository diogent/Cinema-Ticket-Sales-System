using ApplicationDbMovies.Models;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CinemaTicketSalesBusinessLogic.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<ApplicationUser, UserModel>()
                .ForMember(x => x.Roles, o => o.Ignore());
        }
    }
}
