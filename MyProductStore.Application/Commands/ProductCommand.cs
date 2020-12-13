using MediatR;
using MyProductStore.Application.DTOs.Output;

namespace MyProductStore.Application.Commands
{
    //TODO this class should be refactor. Id must no be passed for POST
    public class ProductCommand : IRequest<ProductOutputDto>
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public short Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
