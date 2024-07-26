using ProjeWebApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Application.Feature.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public BrandDto Brand { get; set; }
    }
}
