using ProjeWebApi.Persistence.UnitofWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjeWebApi.Application.Interface.Repositories;
using ProjeWebApi.Application.Interface.UnitofWorks;
using ProjeWebApi.Persistence.Context;
using ProjeWebApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Persistence
{ 
     // Configruasiya işlemlerini bu class vasiitesile edeceyik
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            // IServiceCollection.Addpersistence()

            services.AddDbContext<AppDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Burada Development appsettings-in connectionstringini tanıtmalıyıq.

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitofWork,UnitofWork>();



            //Burada dependency injection işlemide heyata keçirilir

        }





    }
}
