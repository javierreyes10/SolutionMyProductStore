using FluentValidation;
using MyProductStore.Application.Commands;

namespace MyProductStore.Application.Validators
{
    public class ProductValidator : AbstractValidator<ProductCommand>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Product name is required");

            RuleFor(p => p.Name)
                .MaximumLength(100)
                .NotEmpty()
                .WithMessage("Product Name cannot be greater than 100");

            RuleFor(p => p.Quantity)
                .NotNull()
                .NotEmpty()
                .WithMessage("Product quantity is required");

            RuleFor(p => p.Quantity)
                .GreaterThan((short)0)
                .WithMessage("Product quantity must be greater than 0");

            RuleFor(p => p.Price)
                .GreaterThan(0)
                .WithMessage("Product price must be greater than 0");

            RuleFor(p => p.Description)
                .MaximumLength(250)
                .WithMessage("Product description cannot be greater than 250 characteres");

            RuleFor(p => p.Image)
                .MaximumLength(500)
                .WithMessage("Product image cannot be greater than 500 characteres");

            RuleFor(p => p.SKU)
                .MaximumLength(20)
                .WithMessage("Product SKU cannot be greater than 20 characteres");
        }
    }
}
