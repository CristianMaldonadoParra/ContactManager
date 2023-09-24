using TemplateSolution.Domain.Commands.Validations;

namespace TemplateSolution.Domain.Commands.Contatos
{
    public class Contatos_UpdateCommand : Contatos_Command
    {
        public Contatos_UpdateCommand(int Id, string Tipo, string Valor, int? PessoaId)
        {
            this.Id = Id;
            this.Tipo = Tipo;   
            this.Valor = Valor; 
            this.PessoaId = PessoaId;
        }

        public override bool IsValid()
        {
            ValidationResult = new Contatos_UpdateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
