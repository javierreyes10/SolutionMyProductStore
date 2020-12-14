using MediatR;
using MyProductStore.Application.DTOs.Input;
using MyProductStore.Application.DTOs.Output;

namespace MyProductStore.Application.Commands
{
    public class BaseProductCommand : IRequest<ProductOutputDto>
    {
        public ProductInputDto Product { get; set; }

        public BaseProductCommand(ProductInputDto product)
        {
            Product = product;
        }
    }
}
