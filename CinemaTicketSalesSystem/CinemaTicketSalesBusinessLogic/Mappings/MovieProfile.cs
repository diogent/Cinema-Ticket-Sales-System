using ApplicationDbMovies.Models;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;

namespace CinemaTicketSalesBusinessLogic.Mappings
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieInfoModel>();
            CreateMap<Movie, MovieModel>();
            CreateMap<CreateMovieModel, Movie>()
                .ForMember(x => x.Name, o => o.MapFrom(s => s.Name))
                .ForMember(x => x.Pictures, o => o.MapFrom(s => s.Pictures))
                .ForMember(x => x.Description, o => o.MapFrom(s => s.Description))
                .ForMember(x => x.DateOfPremiere, o => o.MapFrom(s => s.DateOfPremiere))
                .ForMember(x => x.AgeRating, o => o.MapFrom(s => s.AgeRating))
                .ForAllOtherMembers(o => o.Ignore());
        }
    }
}
