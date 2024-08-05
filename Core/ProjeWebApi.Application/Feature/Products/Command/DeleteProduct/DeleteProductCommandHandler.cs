using MediatR;
using ProjeWebApi.Application.Interface.UnitofWorks;
using ProjeWebApi.Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeWebApi.Application.Feature.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IUnitofWork unitofWork;

        public DeleteProductCommandHandler(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {

            var product = await unitofWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted); 
            product.IsDeleted = false;
            
            await unitofWork.GetWriteRepository<Product>().UpdateAsync(product);
            await unitofWork.SaveAsync();
        }
    }
}
