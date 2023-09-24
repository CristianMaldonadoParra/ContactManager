using System;
using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace TemplateSolution.Domain.Core.Core.Messaging
{
    public abstract class Event : Message, INotification
    {
        [NotMapped]
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
