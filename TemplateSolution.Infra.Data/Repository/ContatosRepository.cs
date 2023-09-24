using Microsoft.EntityFrameworkCore;
using TemplateSolution.Domain.Core.Core.Data;
using TemplateSolution.Domain.Filters;
using TemplateSolution.Domain.Interfaces;
using TemplateSolution.Domain.Models;
using TemplateSolution.Infra.Data.Context;

namespace TemplateSolution.Infra.Data.Repository
{
    public class ContatosRepository : IContatos_Repository
    {
        protected readonly ContextDB _context;
        protected readonly DbSet<Contatos> DbSet;
        public ContatosRepository(ContextDB context)
        {
            _context = context;
            DbSet = _context.Set<Contatos>();
        }

        public IUnitOfWork UnitOfWork => this._context;
        public void Add(Contatos model)
        {
            DbSet.Add(model);
        }

        public async Task<Contatos> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public Task<Contatos> GetDataCustom(Contatos_Filter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contatos>> GetDataListCustom(Contatos_Filter filter)
        {

            var result = await DbSet
                .Where(_ => _.PessoaId == filter.PessoaId)
                .ToListAsync();

            return result;
        }

        public void Remove(Contatos model)
        {
            DbSet.Remove(model);
        }

        public void Update(Contatos model)
        {
            DbSet.Update(model);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
