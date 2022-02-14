using Cinema.Models;
using Cinema.Repository.Interfaces;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Repository.Implementations
{
    public class CastRepository : GenericRepository<Cast>, ICastRepository
    {
        public CastRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
