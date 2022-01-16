using Cinema.Repository.Interfaces;
using Entity;
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

        public Movie GetByTitle(string title)
        {
           Movie searchMovie = _dbSet.FirstOrDefault(x => x.Title == title);
           return searchMovie;
        }
    }
}
