using TemplateSolution.Domain.Core.Core.Messaging;

namespace TemplateSolution.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
