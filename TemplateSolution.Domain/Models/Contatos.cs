using System.ComponentModel.DataAnnotations;
using TemplateSolution.Domain.Core.Core.Domain;

namespace TemplateSolution.Domain.Models
{
    public class Contatos : Entity, IAggregateRoot
    {
        public Contatos(int Id, string Tipo, string Valor, int? PessoaId)
        {
            this.Id = Id;
            this.Tipo = Tipo;
            this.Valor = Valor;
            this.PessoaId = PessoaId;
        }

        // Empty constructor for EF
        public Contatos()
        {

        }

        [Key]
        public int Id { get; private set; }
        public string Tipo { get; private set; }
        public string Valor { get; private set; }
        public int? PessoaId { get; private set; }

        public void setTipo(string tipo)
        {
            this.Tipo = tipo;
        }

        public void setValor(string valor)
        {
            this.Valor = valor;
        }

    }
}
