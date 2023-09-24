using System.Threading.Tasks;

namespace TemplateSolution.Domain.Core.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
