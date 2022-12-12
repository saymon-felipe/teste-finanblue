using FluentValidation;
using teste_finanblue.Models;

namespace teste_finanblue.Validators
{
    public class AddCompanyValidator : AbstractValidator<Company>
    {
        public AddCompanyValidator() 
        {
            RuleFor(m => m.name)
                .NotEmpty()
                    .WithMessage("O nome não pode ser vazio")
                .MaximumLength(50)
                    .WithMessage("O nome precisa ter até 50 caracteres")
                .MinimumLength(5)
                    .WithMessage("O nome precisa ter ao menos 5 caracteres");
        }
    }
}
