using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TemplateSolution.Domain.Core.Core.Data;
using TemplateSolution.Domain.Core.Core.Mediator;
using TemplateSolution.Domain.Core.Core.Messaging;
using TemplateSolution.Domain.Models;

namespace TemplateSolution.Infra.Data.Context
{
    public class ContextDB : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ContextDB(DbContextOptions<ContextDB> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Pessoas> Pessoas { get; set; }
        public DbSet<Contatos> Contatos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            var success = await SaveChangesAsync() > 0;

            if (success)
            {
                //await _mediatorHandler.PublishDomainEvents(this).ConfigureAwait(false);
            }

            return success;
        }
    }
}
