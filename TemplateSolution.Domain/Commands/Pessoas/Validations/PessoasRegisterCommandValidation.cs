using TemplateSolution.Domain.Commands.Pessoas;

namespace TemplateSolution.Domain.Commands.Validations
{
    public class Pessoas_RegisterCommandValidation : Pessoas_Validation<Pessoas_RegisterCommand>
    {
        public Pessoas_RegisterCommandValidation()
        {
            ValidateIdRegister();
            ValidateNome();
        }
    }
}
