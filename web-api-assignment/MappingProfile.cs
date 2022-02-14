using AutoMapper;
using Cinema.Models.DataTransferObject;
using Entity;
using System.Linq;
using System.Text;

namespace web_api_assignment
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// This class converts DTO to Models 
        /// </summary>
        public MappingProfile()
        {
            CreateMap<NewMovieDTO, Movie>();
            CreateMap<Movie, MovieToShowDTO>().ForMember(movieToShow => movieToShow.NameOfCasts, options => options.MapFrom(source => source.MovieCasts.Select(t => (t.Cast.FirstName + " " + t.Cast.LastName))))
                                              .ForMember(movieToShow => movieToShow.Categories, options => options.MapFrom(source => source.MovieCategories.Select(t => t.Category.Name)));
            CreateMap<CreateAccountDTO, Account>();
        }
    }
}
