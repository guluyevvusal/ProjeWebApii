using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Application.Feature.Products.Command.CreateProduct
{
    public class CreateProductCommandRequest:IRequest
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }


        public IList<int> CategoryIds { get; set; }
        public int Id { get; internal set; }
    }
}
