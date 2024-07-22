using ProjeWebApi.Application.Interface.Repositories;
using ProjeWebApi.Application.Interface.UnitofWorks;
using ProjeWebApi.Persistence.Context;
using ProjeWebApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Persistence.UnitofWorks
{
    public class UnitofWork : IUnitofWork
    {

        private readonly AppDbContext dbContext;

        public UnitofWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }





        public async ValueTask DisposeAsync()=> await dbContext.DisposeAsync();
    



        public int Save() =>dbContext.SaveChanges();
     



        public async Task<int> SaveAsync()=>await dbContext.SaveChangesAsync();
       



        IReadRepository<T> IUnitofWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);
        



        IWriteRepository<T> IUnitofWork.GetWriteRepository<T>() =>new WriteRepository<T>(dbContext);
       
    }
}
