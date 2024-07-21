using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjeWebApi.Persistence.Context;
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

            // Burada Developmen appsettings-in connectionstringini tanıtmalıyıq.


        }





    }
}
