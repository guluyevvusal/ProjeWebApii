using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeWebApi.Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Persistence.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {


            Category category1 = new()
            {
                Id = 1,
                Name = "Elektron category",
                Priority = 1,  // sırada 1. gelir deye 1 vermişik
                ParentId = 0,  // bundan başqa category yoxdur diye 0 olur, yeni ilk category
                IsDeleted = false,
                CreateDate = DateTime.Now,
            };

            Category category2 = new()
            {
                Id = 2,
                Name = "Moda category",
                Priority = 2,
                ParentId = 0,
                IsDeleted = false,
                CreateDate = DateTime.Now,
            };

            Category parent1 = new()
            {
                Id = 3,
                Name = "Laptop",
                Priority = 1,
                ParentId = 1,
                IsDeleted = false,
                CreateDate = DateTime.Now,
            };

            Category parent2 = new()
            {
                Id = 4,
                Name = "Women",
                Priority = 1,
                ParentId = 2,
                IsDeleted = false,
                CreateDate = DateTime.Now,
            };

            builder.HasData(category1, category2, parent1, parent2);
        }
    }
}
