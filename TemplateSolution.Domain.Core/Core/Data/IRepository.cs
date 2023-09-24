using TemplateSolution.Domain.Core.Core.Domain;
using System;

namespace TemplateSolution.Domain.Core.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
