using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProjeWebApi.Application.Interface.Repositories;
using ProjeWebApi.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntitybase, new()
    {
        private readonly DbContext dbContext;

        public ReadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        private DbSet<T> Table { get => dbContext.Set<T>(); }

      
        
        
        
       public  async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();

            if (predicate is not null) Table.Where(predicate);
            
            return await Table.CountAsync();
        }
         
      
        
      
        public  IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking =  false)
        {
            if (!enableTracking) Table.AsNoTracking();

            return  Table.Where(predicate);
        }

     
        
        
      
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> query = Table;
                                                               // Çünki, burada yalnız read işlemi olacaq
            if (!enableTracking) query = query.AsNoTracking(); // Tracking ( izleme ) mexanizmasını deaktiv edirem
       
            if ( include is not  null ) query = include(query); // her hansı veri varsa onları tutmağımız üçün

            if (predicate is not null) query = query.Where(predicate);  //Şert veririk predicate null deyilse , o zaman predicate bax

            if (orderBy is not null) 
                return  await orderBy(query).ToListAsync(); // sıralayır ve list şeklinde getirir query-ni

            return await query.ToListAsync();
        
        }                                                      

    
        
        
        
        public  async Task<List<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> query = Table;
           
            if (!enableTracking) query = query.AsNoTracking(); 

            if (include is not null) query = include(query); 

            if (predicate is not null) query = query.Where(predicate);  

            if (orderBy is not null)
                return await orderBy(query).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync(); 
                // neçedene veri getireceyini qeyd edirik burada


            return await query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

       
        
        
        
        
        
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, 
            bool enableTracking = false)
        {
            IQueryable<T> query = Table;
           
            if (!enableTracking) query = query.AsNoTracking(); 

            if (include is not null) query = include(query); 

              //  query.Where(predicate);


            return await query.FirstOrDefaultAsync(predicate);
        }
    }
}
