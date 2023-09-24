using TemplateSolution.Domain.Commands.Pessoas;

namespace TemplateSolution.Domain.Commands.Validations
{
    public class Pessoas_RemoveCommandValidation : Pessoas_Validation<Pessoas_RemoveCommand>
    {
        public Pessoas_RemoveCommandValidation()
        {
            ValidateId();
        }
    }
}
