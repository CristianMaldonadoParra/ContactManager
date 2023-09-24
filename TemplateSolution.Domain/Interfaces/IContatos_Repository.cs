using TemplateSolution.Domain.Core.Core.Data;
using TemplateSolution.Domain.Filters;
using TemplateSolution.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemplateSolution.Domain.Interfaces
{
    public interface IContatos_Repository : IRepository<Contatos>
    {
        Task<Contatos> GetById(int id);
        Task<Contatos> GetDataCustom(Contatos_Filter filter);
        Task<IEnumerable<Contatos>> GetDataListCustom(Contatos_Filter filter);

        void Add(Contatos model);
        void Update(Contatos model);
        void Remove(Contatos model);
    }
}
