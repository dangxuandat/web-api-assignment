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
    public class AuditoriumRepository : GenericRepository<Auditorium>, IAuditoriumRepository
    {
        public AuditoriumRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
