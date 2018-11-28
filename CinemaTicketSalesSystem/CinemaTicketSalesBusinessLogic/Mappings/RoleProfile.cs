using ApplicationDbMovies.Models;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CinemaTicketSalesBusinessLogic.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<ApplicationRole, RoleModel>()
                .ForMember(x => x.Name, o => o.MapFrom(s => s.Name))
                .ForAllOtherMembers(o => o.Ignore());
        }
    }
}
