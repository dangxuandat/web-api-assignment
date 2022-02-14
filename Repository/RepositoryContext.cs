using Cinema.Models;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCasts>()
                .HasKey(key => new { key.MovieId, key.CastId });
            modelBuilder.Entity<MovieCasts>().HasOne<Movie>(movie => movie.Movie)
                                            .WithMany(s => s.MovieCasts)
                                            .HasForeignKey(key => key.MovieId);

            modelBuilder.Entity<MovieCasts>().HasOne<Cast>(cast => cast.Cast)
                                            .WithMany(s => s.MovieCasts)
                                            .HasForeignKey(key => key.CastId);
            modelBuilder.Entity<MovieCategory>().HasKey(key => new { key.MovieId, key.CategoryId });

            modelBuilder.Entity<MovieCategory>().HasOne<Movie>(movie => movie.Movie)
                                                .WithMany(s => s.MovieCategories)
                                                .HasForeignKey(key => key.MovieId);

            modelBuilder.Entity<MovieCategory>().HasOne<Category>(category => category.Category)
                                                .WithMany(s => s.MovieCategories)
                                                .HasForeignKey(key => key.CategoryId);
            modelBuilder.Entity<MovieShowtimes>().HasKey(key => new { key.MovieId, key.ShowtimesId });

            modelBuilder.Entity<MovieShowtimes>().HasOne<Movie>(movie => movie.Movie)
                                                 .WithMany(s => s.MovieShowtimes)
                                                 .HasForeignKey(key => key.MovieId);

            modelBuilder.Entity<MovieShowtimes>().HasOne<Showtimes>(showtimes => showtimes.Showtimes)
                                                 .WithMany(s => s.MovieShowtimes)
                                                 .HasForeignKey(key => key.ShowtimesId);

            modelBuilder.Entity<ReservationSeatReservation>().HasKey(key => new { key.ReservationId, key.SeatReservationId });

            modelBuilder.Entity<ReservationSeatReservation>().HasOne<Reservation>(reservation => reservation.Reservation)
                                                             .WithMany(s => s.ReservationSeatReservations)
                                                             .HasForeignKey(key => key.ReservationId);

            modelBuilder.Entity<ReservationSeatReservation>().HasOne<SeatReservation>(reservation => reservation.SeatReservation)
                                                             .WithMany(s => s.ReservationSeatReservations)
                                                             .HasForeignKey(key => key.SeatReservationId);

            modelBuilder.Entity<ShowtimesAuditorium>().HasKey(key => new { key.ShowtimesId, key.AuditoriumId });

            modelBuilder.Entity<ShowtimesAuditorium>().HasOne<Showtimes>(reservation => reservation.Showtimes)
                                                             .WithMany(s => s.ShowtimesAuditoriums)
                                                             .HasForeignKey(key => key.ShowtimesId);

            modelBuilder.Entity<ShowtimesAuditorium>().HasOne<Auditorium>(auditoriums => auditoriums.Auditorium)
                                                             .WithMany(s => s.ShowtimesAuditoriums)
                                                             .HasForeignKey(key => key.AuditoriumId);

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatReservation> seatReservations { get; set; }
        public DbSet<Showtimes> Showtimes { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCasts> MovieCasts { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<MovieShowtimes> MovieShowtimes { get; set; }
        public DbSet<ReservationSeatReservation> ReservationSeatReservations { get; set; }
        public DbSet<ShowtimesAuditorium> ShowtimesAuditoriums { get; set; }

    }
}
