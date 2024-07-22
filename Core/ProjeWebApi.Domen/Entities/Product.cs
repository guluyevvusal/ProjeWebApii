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
        public  string Description { get; set; }
        public  string Title { get; set; }
        public  int BrandId { get; set; }
        public  decimal Price { get; set; }
        public  decimal Discount { get; set; }

        public Brand Brand { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
