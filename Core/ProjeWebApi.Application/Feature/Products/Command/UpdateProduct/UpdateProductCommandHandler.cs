using MediatR;
using MediatR.Pipeline;
using ProjeWebApi.Application.Feature.Products.Command.CreateProduct;
using ProjeWebApi.Application.Interface.AutoMapper;
using ProjeWebApi.Application.Interface.UnitofWorks;
using ProjeWebApi.Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Application.Feature.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }



        public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            var product = await unitofWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            var map = mapper.Map<Product, UpdateProductCommandRequest>(request);
           
            var productCategories = await unitofWork.GetReadRepository<ProductCategory>()
                .GetAllAsync(x => x.ProductId == product.Id);
           
            await unitofWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);


            foreach (var categoryId in request.CategoryIds)
                
                await unitofWork.GetWriteRepository<ProductCategory>()
                .AddAsync(new() { CategoryId = categoryId, ProductId = product.Id });
            await unitofWork.GetWriteRepository<Product>().UpdateAsync(product); 
            
            await unitofWork.SaveAsync();

        }
    }
}
