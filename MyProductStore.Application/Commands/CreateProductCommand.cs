using MyProductStore.Application.DTOs.Input;

namespace MyProductStore.Application.Commands
{
    public class CreateProductCommand : BaseProductCommand
    {
        public CreateProductCommand(ProductInputDto product) : base(product)
        {
        }
    }
}
