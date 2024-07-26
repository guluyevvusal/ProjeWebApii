using MediatR;
using MediatR.Pipeline;
using ProjeWebApi.Application.DTOs;
using ProjeWebApi.Application.Interface.AutoMapper;
using ProjeWebApi.Application.Interface.UnitofWorks;
using ProjeWebApi.Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Application.Feature.Products.Queries.GetAllProducts
{
    // Handler Request ile Response arasında elaqe yaradır.
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }

        // Burada field-ler yaradırıq.







        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitofWork.GetReadRepository<Product>().GetAllAsync();
            //Burada productlarımızı alırıq, daha sonra ise response göndereceyik


          var brand = mapper.Map<BrandDto, Brand>(new Brand());

            var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);

            foreach (var item in map)
                item.Price -= (item.Price * item.Discount / 1000);
       
         return map;
        }
       
    }
}
