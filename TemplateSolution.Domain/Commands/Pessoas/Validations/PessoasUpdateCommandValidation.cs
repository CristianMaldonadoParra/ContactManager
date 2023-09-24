using TemplateSolution.Domain.Commands.Pessoas;

namespace TemplateSolution.Domain.Commands.Validations
{
    public class Pessoas_UpdateCommandValidation : Pessoas_Validation<Pessoas_UpdateCommand>
    {
        public Pessoas_UpdateCommandValidation()
        {
            ValidateId();
            ValidateNome();
        }
    }
}
