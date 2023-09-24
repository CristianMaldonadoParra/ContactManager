using Microsoft.EntityFrameworkCore;
using TemplateSolution.Domain.Core.Core.Data;
using TemplateSolution.Domain.Filters;
using TemplateSolution.Domain.Interfaces;
using TemplateSolution.Domain.Models;
using TemplateSolution.Infra.Data.Context;

namespace TemplateSolution.Infra.Data.Repository
{
    public class PessoasRepository : IPessoas_Repository
    {
        protected readonly ContextDB _context;
        protected readonly DbSet<Pessoas> DbSet;
        public PessoasRepository(ContextDB context)
        {
            _context = context;
            DbSet = _context.Set<Pessoas>();
        }

        public IUnitOfWork UnitOfWork => this._context;

        public void Add(Pessoas model)
        {
            DbSet.Add(model);
        }

        public async Task<Pessoas> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public Task<Pessoas> GetDataCustom(Pessoas_Filter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pessoas>> GetDataListCustom(Pessoas_Filter filter)
        {
            
            var result = await DbSet.ToListAsync();

            return result;
        }

        public void Remove(Pessoas model)
        {
            DbSet.Remove(model);
        }

        public void Update(Pessoas model)
        {
            DbSet.Update(model);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
