using AutoMapper;
using Cinema.Models;
using Cinema.Models.DataTransferObject;
using Cinema.Repository.Interfaces;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        [HttpGet("/movies")]
        public IActionResult GetAllMovies()
        {
            IEnumerable<Movie> listOfMovies = _unitOfWork.Movies.Get(null,null,"Cast,Category");
            IEnumerable<MovieToShowDTO> movieToShows = _mapper.Map<IEnumerable<MovieToShowDTO>>(listOfMovies);
            return Ok(movieToShows);
        }



        //[HttpPost("/movies")]
        //public IActionResult InsertNewMovie()
        //{
            //Guid guid = new Guid("861AF30F-7754-4061-8A84-08D9D8CE7D15");
            //Role customerRole = _unitOfWork.Role.GetById(guid);
            //Account newAccount = new Account() { FirstName ="Dang", LastName = "Dat" , UserName ="dangdat" ,Password ="123456789", Role = customerRole};
            //_unitOfWork.Accounts.Insert(newAccount);
            //_unitOfWork.Save();
            //return Ok(newAccount.Id);
            //Category category = new Category() { Name = "Phim Kinh Di"};
            //Category category1 = new Category() { Name = "Phim Hanh Dong"};
            //Category category2 = new Category() { Name = "Phim Vien Tuong"};
            //Cast cast1 = new Cast() { FirstName= "Dang",LastName = "Duc"};
            //Cast cast2 = new Cast() { FirstName= "Le Quang",LastName = "Ky"};
            //Cast cast3 = new Cast() { FirstName= "Dang Dong",LastName = "Quan" };
            //Movie newMovie = new Movie() { Title = "Bong Dem", Director = "Vinh Bay", Duration = 130, Description = "Con ac mong tro lai, ban se lam gi" };
            //newMovie.MovieCategories = new List<MovieCategory>()
            //{
            //    new MovieCategory
            //    {
            //        Movie = newMovie,
            //        Category = category1
            //    },
            //    new MovieCategory
            //    {
            //        Movie = newMovie,
            //        Category = category
            //    },
            //    new MovieCategory
            //    {
            //        Movie = newMovie,
            //        Category = category2
            //    }
            //};
            //newMovie.MovieCasts = new List<MovieCast>()
            //{
            //    new MovieCast
            //    {
            //        Movie = newMovie,
            //        Cast = cast1,
            //    },
            //    new MovieCast
            //    {
            //        Movie = newMovie,
            //        Cast = cast2,
            //    },
            //    new MovieCast
            //    {
            //        Movie = newMovie,
            //        Cast = cast3,
            //    },
            //};
            //_unitOfWork.Movies.Insert(newMovie);
            //_unitOfWork.Save();
            //Showtimes showtimes = new Showtimes() { StartTime = DateTime.Now,EndTime = DateTime.Now.AddMinutes(120)};
            //Auditorium auditorium = new Auditorium() { Name = "Rap 1", SeatNumbers = 100};
            //Movie movie = _unitOfWork.Movies.GetByTitle("Bong Dem");
            //showtimes.ShowtimesAuditoriums = new List<ShowtimesAuditorium>() {
            //    new ShowtimesAuditorium()
            //    {
            //        Auditorium = auditorium,
            //        Showtimes = showtimes
            //    }
            //};
            //showtimes.MovieShowtimes = new List<MovieShowtimes>()
            //{
            //    new MovieShowtimes()
            //    {
            //        Movie = movie,
            //        Showtimes = showtimes,
            //    }
            //};
            //_unitOfWork.Showtimes.Insert(showtimes);
            //_unitOfWork.Save();
            //Seat seat;
            //Guid guid = new Guid("8DEACE73-F10E-4518-953F-08D9D8E17081");
            //Auditorium auditorium = _unitOfWork.Auditoriums.GetById(guid);
            //for (char c = 'A'; c <= 'E'; c++)
            //{
            //    for(int i = 1; i <= 10; i++)
            //    {
            //        seat = new Seat() { Row = c, Number = i, Auditorium = auditorium};
            //       _unitOfWork.Seats.Insert(seat);
            //    }
            //}
            //Guid guid = new Guid("D2C1F743-051E-4CAA-CDEF-08D9D8DDDBD4");
            //Account account = _unitOfWork.Accounts.GetById(guid);
            //Guid guid1 = new Guid("FA0228CC-AAC9-425C-6A4F-08D9D8E1707A");
            //Showtimes showtimes = _unitOfWork.Showtimes.GetById(guid1);
            //Reservation reservation = new Reservation() { Account = account, Showtimes = showtimes };
            //Seat seat = _unitOfWork.Seats.GetById(new Guid("1481EE20-3842-4242-2626-08D9D8E48378"));
            //SeatReservation seatReservation = new SeatReservation() { Seat = seat };
            //reservation.ReservationSeatReservations = new List<ReservationSeatReservation>()
            //{
            //    new ReservationSeatReservation()
            //    {
            //        Reservation = reservation,
            //        SeatReservation = seatReservation,
            //    }
            //};
            //_unitOfWork.Reservations.Insert(reservation);
            //_unitOfWork.Save();
            //return Ok();
        //}
    }
}
