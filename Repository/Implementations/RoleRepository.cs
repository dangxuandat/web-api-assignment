using Cinema.Repository.Interfaces;
using Entity;
using Repository;
using System;
using System.Linq;

namespace Cinema.Repository.Implementations
{
    public class RoleRepository : GenericRepository<Role>, IRole
    {
        public RoleRepository(RepositoryContext context) : base(context)
        {
        }

        public Role GetRoleById(Guid roleId)
        {
            Role role = _dbSet.Find(roleId);
            return role;
        }

        public Role GetRoleByName(string name)
        {
            Role role = _dbSet.Where(x => x.Name == name).FirstOrDefault();
            return role;
        }
    }
}
