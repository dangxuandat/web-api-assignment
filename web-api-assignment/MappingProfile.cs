using AutoMapper;
using Cinema.Models.DataTransferObject;
using Entity;

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
            CreateMap<Movie, MovieToShowDTO>();
            CreateMap<NewRoleDTO, Role>();
        }
    }
}
