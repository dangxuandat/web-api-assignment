using Cinema.Repository.Interfaces;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext _context;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuditoriumRepository _auditoriumRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly ISeatReservationRepository _seatReservationRepository;
        private readonly IShowtimesRepository _showtimesRepository;
        private readonly IRole _roleRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly ICastRepository _castRepository;
        private readonly ICategoryRepository _categoryRepository;
        private bool _disposed = false;
        public UnitOfWork(RepositoryContext context, IAccountRepository accountRepository,IAuditoriumRepository auditoriumRepository,
            IMovieRepository movieRepository, IReservationRepository reservationRepository, ISeatReservationRepository seatReservationRepository,
            IShowtimesRepository showtimesRepository, IRole roleRepository, ISeatRepository seatRepository , ICastRepository castRepository, ICategoryRepository categoryRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
            _auditoriumRepository = auditoriumRepository;
            _movieRepository = movieRepository;
            _reservationRepository = reservationRepository;
            _seatReservationRepository = seatReservationRepository;
            _categoryRepository = categoryRepository;
            _showtimesRepository = showtimesRepository;
            _roleRepository = roleRepository;
            _seatRepository = seatRepository;
            _castRepository = castRepository;
        }

        public IAccountRepository Accounts { get => _accountRepository; }
        public IAuditoriumRepository Auditoriums { get => _auditoriumRepository; }
        public IMovieRepository Movies { get => _movieRepository; }
        public IReservationRepository Reservations { get => _reservationRepository; }
        public ISeatReservationRepository SeatReservations { get => _seatReservationRepository; }
        public IShowtimesRepository Showtimes { get => _showtimesRepository; }

        public ICategoryRepository Category { get => _categoryRepository;  }
        public IRole Roles
        {
            get => _roleRepository;
        }

        public ISeatRepository Seats
        {
            get => _seatRepository;
        }

        public ICastRepository Casts
        {
            get => _castRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
