using ApplicationDbMovies.Models;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Models;

namespace CinemaTicketSalesBusinessLogic.Mappings
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieInfoModel>()
                .ForMember(x=> x.MovieId, o => o.MapFrom(s => s.Id))
                .ForMember(x => x.MovieName, o => o.MapFrom(s => s.Name));
            CreateMap<Movie, MovieModel>();
            CreateMap<Movie, LearnMoreMovieModel>();
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
