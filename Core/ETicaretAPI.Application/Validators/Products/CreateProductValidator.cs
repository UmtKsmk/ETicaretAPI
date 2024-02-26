using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please do not leave the product name blank.")
                .MaximumLength(150)
                .MinimumLength(1)
                    .WithMessage("Please enter the product name between 1 and 150 characters.");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please don't leave stock information blank.")
                .Must(s => s >= 0)
                    .WithMessage("Stock information can't be negative!");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please don't leave price information blank.")
                .Must(s => s >= 0)
                    .WithMessage("Price information can't be negative!");
        }
    }
}
