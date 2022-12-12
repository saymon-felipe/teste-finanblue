using FluentValidation;
using teste_finanblue.Models;

namespace teste_finanblue.Validators
{
    public class AddUserValidator : AbstractValidator<User>
    {
        public AddUserValidator() 
        {
            RuleFor(m => m.name)
                .NotEmpty()
                    .WithMessage("O nome não pode ser vazio")
                .MaximumLength(50)
                    .WithMessage("O nome precisa ter até 50 caracteres")
                .MinimumLength(5)
                    .WithMessage("O nome precisa ter mais de 5 caracteres");

            RuleFor(m => m.email)
                .NotEmpty()
                    .WithMessage("O email não pode ser vazio")
                .EmailAddress()
                    .WithMessage("O email deve ser válido");

            RuleFor(m => m.password)
                .NotEmpty()
                    .WithMessage("A senha não pode ser vazia")
                .MaximumLength(50)
                    .WithMessage("A senha precisa ter até 50 caracteres")
                .MinimumLength(5)
                    .WithMessage("A senha precisa ter mais de 5 caracteres");
        }
    }
}
