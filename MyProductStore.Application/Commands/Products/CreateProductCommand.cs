using MyProductStore.Application.DTOs.Input;

namespace MyProductStore.Application.Commands.Products
{
    public class CreateProductCommand : BaseProductCommand
    {
        public CreateProductCommand(ProductInputDto product) : base(product)
        {
        }
    }
}
