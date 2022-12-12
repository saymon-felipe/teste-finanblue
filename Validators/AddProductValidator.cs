using FluentValidation;
using teste_finanblue.Models;

namespace teste_finanblue.Validators
{
    public class AddProductValidator : AbstractValidator<Product>
    {
        public AddProductValidator() 
        {
            RuleFor(m => m.name)
                .NotEmpty()
                    .WithMessage("O nome não pode ser vazio")
                .MaximumLength(50)
                    .WithMessage("O nome precisa ter até 50 caracteres");

            RuleFor(m => m.price)
                .NotEmpty()
                    .WithMessage("O preço não pode ser vazio");
        }
    }
}
