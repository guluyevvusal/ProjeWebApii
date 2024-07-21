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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new("en");

            Product product1 = new()
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 1,
                Discount = faker.Random.Decimal(0,10),
                Price = faker.Finance.Amount(0,1000),
                CreateDate = DateTime.Now,
                IsDeleted = false,
            };

            Product product2 = new()
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 3,
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(0, 1000),
                CreateDate = DateTime.Now,
                IsDeleted = false,
            };

            builder.HasData(product1,product2);
        }
    }
}
