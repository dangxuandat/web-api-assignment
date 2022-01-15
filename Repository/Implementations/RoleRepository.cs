using Cinema.Repository.Interfaces;
using Entity;
using Repository;
using System;

namespace Cinema.Repository.Implementations
{
    public class RoleRepository : GenericRepository<Role>, IRole
    {
        public RoleRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
