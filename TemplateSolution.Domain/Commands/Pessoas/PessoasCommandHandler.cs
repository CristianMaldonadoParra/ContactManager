using FluentValidation.Results;
using MediatR;
using TemplateSolution.Domain.Core.Core.Messaging;
using TemplateSolution.Domain.Interfaces;

namespace TemplateSolution.Domain.Commands.Pessoas
{
    public class Pessoas_CommandHandler : CommandHandler,
        IRequestHandler<Pessoas_RegisterCommand, ValidationResult>,
        IRequestHandler<Pessoas_UpdateCommand, ValidationResult>,
        IRequestHandler<Pessoas_RemoveCommand, ValidationResult>
    {
        private readonly IPessoas_Repository _pessoas_Repository;
        
        public Pessoas_CommandHandler(IPessoas_Repository Pessoas_Repository)
        {
            _pessoas_Repository = Pessoas_Repository;
        }

        public async Task<ValidationResult> Handle(Pessoas_RegisterCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid()) return command.ValidationResult;

            Models.Pessoas pessoa = new Models.Pessoas(command.Id, command.Nome);

            _pessoas_Repository.Add(pessoa);
            
            var result = await Commit(_pessoas_Repository.UnitOfWork);

            command.Id = pessoa.Id;
            
            return result;
        }

        public async Task<ValidationResult> Handle(Pessoas_UpdateCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid()) return command.ValidationResult;
            
            Models.Pessoas pessoa = await _pessoas_Repository.GetById(command.Id);
            
            if(pessoa is null)
            {
                AddError("Nao foi possivel realizar a atualização do registro!.");
                return ValidationResult;
            }

            pessoa.setNome(command.Nome);

            _pessoas_Repository.Update(pessoa);

            var result = await Commit(_pessoas_Repository.UnitOfWork);
            
            return result;
        }

        public async Task<ValidationResult> Handle(Pessoas_RemoveCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid()) return command.ValidationResult;
            
            Models.Pessoas pessoa = await _pessoas_Repository.GetById(command.Id);

            if (pessoa is null)
            {
                AddError("Nao foi possivel realizar a exclusão do registro!.");
                return ValidationResult;
            }

            _pessoas_Repository.Remove(pessoa);
            
            return await Commit(_pessoas_Repository.UnitOfWork);
        }

        public void Dispose()
        {
            _pessoas_Repository.Dispose();
        }

        
    }
}
