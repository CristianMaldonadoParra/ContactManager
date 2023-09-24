using TemplateSolution.Domain.Commands.Validations;

namespace TemplateSolution.Domain.Commands.Pessoas
{
    public class Pessoas_RemoveCommand : Pessoas_Command
    {
        public Pessoas_RemoveCommand(int Id)
        {
            this.Id = Id;
            AggregateId = new Guid();
        }

        public override bool IsValid()
        {
            ValidationResult = new Pessoas_RemoveCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
