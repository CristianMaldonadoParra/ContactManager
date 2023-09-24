using TemplateSolution.Domain.Commands.Validations;

namespace TemplateSolution.Domain.Commands.Pessoas
{
    public class Pessoas_RegisterCommand : Pessoas_Command
    {
        public Pessoas_RegisterCommand(int Id, string Nome)
        {
            this.Id = Id;
            this.Nome = Nome;

        }

        public override bool IsValid()
        {
            ValidationResult = new Pessoas_RegisterCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
