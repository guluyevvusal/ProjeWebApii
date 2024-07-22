using Microsoft.EntityFrameworkCore.Query;
using ProjeWebApi.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Application.Interface.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntitybase, new()
    {
        Task AddAsync(T entity);

        Task AddRangAsync(IList<T> entities);

        Task<T> UpdateAsync(T entity);

        Task HardDeleteAsync(T entity);

     
    
    
    
    }
}
