using FluentValidation;
using TemplateSolution.Domain.Commands.Contatos;

namespace TemplateSolution.Domain.Commands.Validations
{
    public abstract class Contatos_Validation<T> : AbstractValidator<T> where T : Contatos_Command
    {
        protected void ValidateId()
        {
            //RuleFor(c => c.ID)
            //    .NotEmpty().WithMessage("O campo Id deve estar preenchido");
        }
    }
}
