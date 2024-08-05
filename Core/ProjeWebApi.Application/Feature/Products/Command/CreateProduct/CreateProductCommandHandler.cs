using MediatR;
using ProjeWebApi.Application.Interface.UnitofWorks;
using ProjeWebApi.Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Application.Feature.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IUnitofWork unitofWork;

        public CreateProductCommandHandler(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }
        
        
        
        public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = new(request.Description, request.Title, request.BrandId, request.Price, request.Discount);

            await unitofWork.GetWriteRepository<Product>().AddAsync(product);

            if(await unitofWork.SaveAsync()>0)
            {
                foreach (var categoryId in request.CategoryIds)
                    await unitofWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId,    
                    });

                await unitofWork.SaveAsync();
            }
          
        }
    }
}
