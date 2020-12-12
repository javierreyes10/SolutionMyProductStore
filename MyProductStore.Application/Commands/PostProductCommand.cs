using MediatR;
using MyProductStore.Application.DTOs.Output;

namespace MyProductStore.Application.Commands
{
    public class PostProductCommand : IRequest<ProductOutputDto>
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public short Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
