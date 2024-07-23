using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Application
{
    public static class Registration
    {
        public static void AddAplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(assembly)); 
            //MediaTR-ı burada dependency injectiona elave etmiş oluruq.
        }


    }
}
