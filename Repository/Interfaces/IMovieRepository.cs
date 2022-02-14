using Entity;
using System.Collections.Generic;


namespace Cinema.Repository.Interfaces
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Movie GetByTitle(string title);
        IEnumerable<Movie> GetAllMoviesWithCastsAndCategories();
    }
}
