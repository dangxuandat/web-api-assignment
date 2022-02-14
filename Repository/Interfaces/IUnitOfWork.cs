using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IMovieRepository Movies { get; }
        IAuditoriumRepository Auditoriums { get; }
        IReservationRepository Reservations { get; }
        ISeatReservationRepository SeatReservations { get; }
        IShowtimesRepository Showtimes { get; }
        ISeatRepository Seats { get; }
        IRole Roles { get; }

        ICastRepository Casts { get; }

        ICategoryRepository Category { get; }

        void Save();
    }
}
