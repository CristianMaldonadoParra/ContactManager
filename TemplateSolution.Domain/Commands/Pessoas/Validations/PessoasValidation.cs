using FluentValidation;
using TemplateSolution.Domain.Commands.Pessoas;

namespace TemplateSolution.Domain.Commands.Validations
{
    public abstract class Pessoas_Validation<T> : AbstractValidator<T> where T : Pessoas_Command
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0);
        }

        protected void ValidateIdRegister()
        {
            RuleFor(c => c.Id)
                .Equal(0)
                .WithMessage("O Id não pode ser maior que zero");
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor certifique-se de ter digitado o Nome")
                .Length(2, 150).WithMessage("O Nome deve ter entre 2 e 150 caracteres");
        }
    }
}
