using FluentValidation.Results;
using MediatR;
using TemplateSolution.Domain.Core.Core.Messaging;
using TemplateSolution.Domain.Interfaces;

namespace TemplateSolution.Domain.Commands.Contatos
{
    public class Contatos_CommandHandler : CommandHandler,
        IRequestHandler<Contatos_RegisterCommand, ValidationResult>,
        IRequestHandler<Contatos_UpdateCommand, ValidationResult>,
        IRequestHandler<Contatos_RemoveCommand, ValidationResult>
    {
        private readonly IContatos_Repository _contatos_Repository;

        public Contatos_CommandHandler(IContatos_Repository contatos_Repository)
        {
            _contatos_Repository = contatos_Repository;
        }

        public async Task<ValidationResult> Handle(Contatos_RegisterCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid()) return command.ValidationResult;

            Models.Contatos contato = new Models.Contatos(command.Id, command.Tipo, command.Valor, command.PessoaId);

            _contatos_Repository.Add(contato);

            var result = await Commit(_contatos_Repository.UnitOfWork);

            command.Id = contato.Id;

            return result;

        }

        public async Task<ValidationResult> Handle(Contatos_UpdateCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid()) return command.ValidationResult;

            Models.Contatos contato = await _contatos_Repository.GetById(command.Id);

            if (contato is null)
            {
                AddError("Nao foi possivel realizar a atualização do registro!.");
                return ValidationResult;
            }

            contato.setValor(command.Valor);
            contato.setTipo(command.Tipo);

            _contatos_Repository.Update(contato);

            var result = await Commit(_contatos_Repository.UnitOfWork);

            return result;
        }

        public async Task<ValidationResult> Handle(Contatos_RemoveCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid()) return command.ValidationResult;

            Models.Contatos contato = await _contatos_Repository.GetById(command.Id);

            if (contato is null)
            {
                AddError("Nao foi possivel realizar a exclusão do registro!.");
                return ValidationResult;
            }

            _contatos_Repository.Remove(contato);

            return await Commit(_contatos_Repository.UnitOfWork);

        }

        public void Dispose()
        {
            this._contatos_Repository.Dispose();
        }


    }
}
