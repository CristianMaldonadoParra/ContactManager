using AutoMapper;
using FluentValidation.Results;
using TemplateSolution.Application.Interfaces;
using TemplateSolution.Application.ViewModels;
using TemplateSolution.Domain.Commands.Contatos;
using TemplateSolution.Domain.Core.Core.Mediator;
using TemplateSolution.Domain.Filters;
using TemplateSolution.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateSolution.Domain.Commands.Pessoas;

namespace TemplateSolution.Application.Services
{
    public class Contatos_AppService : IContatos_AppService
    {
        private readonly IMapper _mapper;
        private readonly IContatos_Repository _Contatos_Repository;
        //private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public Contatos_AppService(IMapper mapper,
                                  IContatos_Repository Contatos_Repository,
                                  IMediatorHandler mediator
                                  )
        {
            this._Contatos_Repository = Contatos_Repository;
            this._mapper = mapper;
            this._mediator = mediator;
        }

        public async Task<Contatos_ViewModel> GetById(int id)
        {
            return _mapper.Map<Contatos_ViewModel>(await _Contatos_Repository.GetById(id));
        }

        public async Task<Contatos_ViewModel> GetDataCustom(Contatos_Filter filter)
        {
            return _mapper.Map<Contatos_ViewModel>(await _Contatos_Repository.GetDataCustom(filter));
        }

        public async Task<IEnumerable<Contatos_ViewModel>> GetDataListCustom(Contatos_Filter filter)
        {
            return _mapper.Map<IEnumerable<Contatos_ViewModel>>(await _Contatos_Repository.GetDataListCustom(filter));
        }

        public async Task<Contatos_RegisterCommand> Register(Contatos_ViewModel viewModel)
        {
            var registerCommand = _mapper.Map<Contatos_RegisterCommand>(viewModel);
            var result = await _mediator.SendCommand(registerCommand);
            registerCommand.ValidationResult = result;
            return registerCommand;
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var removeCommand = new Contatos_RemoveCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<Contatos_UpdateCommand> Update(Contatos_ViewModel viewModel)
        {
            var updateCommand = _mapper.Map<Contatos_UpdateCommand>(viewModel);
            var result = await _mediator.SendCommand(updateCommand);
            updateCommand.ValidationResult = result;
            return updateCommand;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
