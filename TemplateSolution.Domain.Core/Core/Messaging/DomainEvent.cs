using System;

namespace TemplateSolution.Domain.Core.Core.Messaging
{
    public abstract class DomainEvent : Event
    {
        protected DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
