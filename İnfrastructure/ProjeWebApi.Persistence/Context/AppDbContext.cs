using Microsoft.EntityFrameworkCore;
using ProjeWebApi.Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Persistence.Context
{
    public class AppDbContext:DbContext

    {
        public AppDbContext() { }
       

        public AppDbContext(DbContextOptions options) : base(options) { }
        

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Category{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Detail> Details { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }

    
}
