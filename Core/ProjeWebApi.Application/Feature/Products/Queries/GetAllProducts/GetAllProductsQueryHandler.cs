using MediatR;
using MediatR.Pipeline;
using ProjeWebApi.Application.Interface.UnitofWorks;
using ProjeWebApi.Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Application.Feature.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitofWork unitofWork;

        public GetAllProductsQueryHandler(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }


        //Request ile Response arasında elaqe yaradır.




        // Burada field-ler yaradırıq.

        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitofWork.GetReadRepository<Product>().GetAllAsync();
            //Burada productlarımızı alırıq, daha sonra ise response göndereceyik



            List<GetAllProductsQueryResponse> response = new();

            foreach (var product in products)
            {
                new GetAllProductsQueryResponse
                {
                    
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price - (product.Price * product.Discount / 100),
                    Discount = product.Discount,

                };
                return response;
            }
        }
    }
}
