using MediatR;
using MyProductStore.Application.Commands;
using MyProductStore.Application.Commands.Products;
using MyProductStore.Application.DTOs.Output;
using MyProductStore.Core.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MyProductStore.Application.Handlers.Products
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ProductOutputDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<ProductOutputDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

            if (product == null) return null;

            _unitOfWork.Products.Remove(product);
            await _unitOfWork.CommitAsync();

            return new ProductOutputDto();
        }
    }
}
