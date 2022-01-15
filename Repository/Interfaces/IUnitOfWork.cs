using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRole Roles { get; }

        void Save();
    }
}
