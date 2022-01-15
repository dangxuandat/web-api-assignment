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
        private bool _disposed = false;
        public UnitOfWork(RepositoryContext context, IAccountRepository accountRepository,IAuditoriumRepository auditoriumRepository,
            IMovieRepository movieRepository, IReservationRepository reservationRepository, ISeatReservationRepository seatReservationRepository,
            IShowtimesRepository showtimesRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
            _auditoriumRepository = auditoriumRepository;
            _movieRepository = movieRepository;
            _reservationRepository = reservationRepository;
            _seatReservationRepository = seatReservationRepository;
            _showtimesRepository = showtimesRepository;
        }
        public IRole Roles { get; }

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
