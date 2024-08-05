using Microsoft.EntityFrameworkCore;
using ProjeWebApi.Application.Interface.Repositories;
using ProjeWebApi.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntitybase, new()
    {
        private readonly DbContext dbContext;

        public WriteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        private DbSet<T> Table { get => dbContext.Set<T>(); }




        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }



        public async Task AddRangAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }



        public async Task HardDeleteAsync(T entity)
        {
           await Task.Run(() => Table.Remove(entity));

            
        }




        public async Task HardDeleteRangeAsync(IList<T> entity)
        {
            await Task.Run(() => Table.RemoveRange(entity));


        }

            public async Task<T> UpdateAsync(T entity)
        {
           await Task.Run(() => Table.Update(entity));

            return entity;
        }
    }
}
