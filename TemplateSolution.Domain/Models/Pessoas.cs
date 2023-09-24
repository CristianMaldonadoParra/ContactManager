using System.ComponentModel.DataAnnotations;
using TemplateSolution.Domain.Core.Core.Domain;

namespace TemplateSolution.Domain.Models
{
    public class Pessoas : IAggregateRoot
    {
        public Pessoas(int Id, string Nome)
        {
            this.Id = Id;
            this.Nome = Nome;   
        }
        // Empty constructor for EF
        public Pessoas()
        {

        }

        [Key]
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public void setNome(string nome)
        {
            this.Nome = nome;
        }
    }
}
