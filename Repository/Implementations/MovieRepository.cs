using Cinema.Repository.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Repository.Implementations
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(RepositoryContext context) : base(context)
        {
        }

        public IEnumerable<Movie> GetAllMoviesWithCastsAndCategories()
        {
            IEnumerable<Movie> listMovies = _dbSet.AsNoTracking().Include(movie => movie.MovieCasts).ThenInclude(movieCasts => movieCasts.Cast).Include(movie => movie.MovieCategories).ThenInclude(movieCategories => movieCategories.Category).ToList();
            return listMovies;
        }

        public Movie GetByTitle(string title)
        {
           Movie searchMovie = _dbSet.FirstOrDefault(x => x.Title == title);
           return searchMovie;
        }
    }
}
