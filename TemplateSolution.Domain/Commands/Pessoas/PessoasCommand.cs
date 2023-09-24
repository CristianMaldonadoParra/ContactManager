using TemplateSolution.Domain.Core.Core.Messaging;
using System;

namespace TemplateSolution.Domain.Commands.Pessoas
{
    public abstract class Pessoas_Command : Command
    {
        public int Id { get; set; }
        public string Nome { get; set; }

    }
}
