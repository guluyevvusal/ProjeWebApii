using ProjeWebApi.Application.Interface.Repositories;
using ProjeWebApi.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Application.Interface.UnitofWorks
{
    public interface IUnitofWork:IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntitybase, new();

        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntitybase, new();

        Task<int> SaveAsync();

        int Save();
    }
}
