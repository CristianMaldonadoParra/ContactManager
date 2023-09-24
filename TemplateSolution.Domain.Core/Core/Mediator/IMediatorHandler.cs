using FluentValidation.Results;
using TemplateSolution.Domain.Core.Core.Messaging;

namespace TemplateSolution.Domain.Core.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
