using AutoMapper;
using Cinema.Models.DataTransferObject;
using Cinema.Repository.Interfaces;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_api_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MovieController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult InsertNewMovie([FromBody]NewMovieDTO newMovie)
        {
            Movie movie = _mapper.Map<Movie>(newMovie);
            _unitOfWork.Movies.Insert(movie);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(InsertNewMovie), movie.Id);
        }
    }
}
