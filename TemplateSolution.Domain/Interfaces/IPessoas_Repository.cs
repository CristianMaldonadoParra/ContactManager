using TemplateSolution.Domain.Core.Core.Data;
using TemplateSolution.Domain.Filters;
using TemplateSolution.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemplateSolution.Domain.Interfaces
{
    public interface IPessoas_Repository : IRepository<Pessoas>
    {
        Task<Pessoas> GetById(int id);
        Task<Pessoas> GetDataCustom(Pessoas_Filter filter);
        Task<IEnumerable<Pessoas>> GetDataListCustom(Pessoas_Filter filter);

        void Add(Pessoas model);
        void Update(Pessoas model);
        void Remove(Pessoas model);
    }
}
