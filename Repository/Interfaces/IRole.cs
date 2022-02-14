using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Repository.Interfaces
{
    public interface IRole : IGenericRepository<Role>
    {
        public Role GetRoleById(Guid roleId);

        public Role GetRoleByName(string name);
    }
}
