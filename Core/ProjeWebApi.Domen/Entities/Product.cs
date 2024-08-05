using ProjeWebApi.Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Domen.Entities
{
    public class Product:Entitybase
    {


        public Product()
        {
            
        }


        public Product(string description, string title, int brandId , decimal price, decimal discount)
        {
            Description = description;
            Title = title;
            BrandId = brandId;
            Price = price;
            Discount = discount;
        }

        public  string Description { get; set; }
        public  string Title { get; set; }
        public  int BrandId { get; set; }
        public  decimal Price { get; set; }
        public  decimal Discount { get; set; }

        public Brand Brand { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
