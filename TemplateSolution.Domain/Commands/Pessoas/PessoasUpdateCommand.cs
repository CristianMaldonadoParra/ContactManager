using TemplateSolution.Domain.Commands.Validations;

namespace TemplateSolution.Domain.Commands.Pessoas
{
    public class Pessoas_UpdateCommand : Pessoas_Command
    {
        public Pessoas_UpdateCommand(int Id, string Nome)
        {
            this.Id = Id;
            this.Nome = Nome;

        }

        public override bool IsValid()
        {
            ValidationResult = new Pessoas_UpdateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
