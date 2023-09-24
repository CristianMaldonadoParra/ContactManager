using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemplateSolution.Domain.Core.Core.Messaging
{
    public abstract class Message
    {
        [NotMapped]
        public string MessageType { get; protected set; }
        [NotMapped]
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
