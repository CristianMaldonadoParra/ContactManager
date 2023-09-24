using TemplateSolution.Domain.Commands.Validations;

namespace TemplateSolution.Domain.Commands.Contatos
{
    public class Contatos_RemoveCommand : Contatos_Command
    {
        public Contatos_RemoveCommand(int Id)
        {
            this.Id = Id;
            AggregateId = new Guid();
        }

        public override bool IsValid()
        {
            ValidationResult = new Contatos_RemoveCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
