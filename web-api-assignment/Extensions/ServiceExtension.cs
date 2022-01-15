using Cinema.Repository.Implementations;
using Cinema.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace web_api_assignment.Extensions
{
    public static class ServiceExtension
    {
        
        /// <summary>
        /// Add all interfaces and implementations in DI container
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository,AccountRepository>();
            services.AddScoped<IAuditoriumRepository,AuditoriumRepository>();
            services.AddScoped<IMovieRepository,MovieRepository>();
            services.AddScoped<IReservationRepository,ReservationRepository>();
            services.AddScoped<ISeatReservationRepository,SeatReservationRepository>();
            services.AddScoped<IShowtimesRepository,ShowtimesRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
    }
}
