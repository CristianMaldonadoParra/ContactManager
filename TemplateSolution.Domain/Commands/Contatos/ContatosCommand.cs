using TemplateSolution.Domain.Core.Core.Messaging;

namespace TemplateSolution.Domain.Commands.Contatos
{
    public abstract class Contatos_Command : Command
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public int? PessoaId { get; set; }

    }
}
