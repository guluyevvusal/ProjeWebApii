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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new("en");

            Detail detail1 = new()
            {
                Id = 1,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 1,  // elektron category aiddir, onun ıd-si 1-dir
                CreateDate = DateTime.Now,
                IsDeleted = false,
            };

            Detail detail2 = new()
            {
                Id = 2,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 3,  // elektron category aiddir, onun ıd-si 1-dir
                CreateDate = DateTime.Now,
                IsDeleted = false,
         
            };


            Detail detail3 = new()
            {
                Id = 3,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 4,  // elektron category aiddir, onun ıd-si 1-dir
                CreateDate = DateTime.Now,
                IsDeleted = true,
            };

            builder.HasData(detail1, detail2, detail3); 
        }
    }
}
