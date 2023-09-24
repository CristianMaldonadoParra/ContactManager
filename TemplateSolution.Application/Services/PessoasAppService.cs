using AutoMapper;
using FluentValidation.Results;
using TemplateSolution.Application.Interfaces;
using TemplateSolution.Application.ViewModels;
using TemplateSolution.Domain.Commands.Pessoas;
using TemplateSolution.Domain.Core.Core.Mediator;
using TemplateSolution.Domain.Filters;
using TemplateSolution.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemplateSolution.Application.Services
{
    public class Pessoas_AppService : IPessoas_AppService
    {
        private readonly IMapper _mapper;
        private readonly IPessoas_Repository _Pessoas_Repository;
        //private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public Pessoas_AppService(IMapper mapper,
                                  IPessoas_Repository Pessoas_Repository,
                                  IMediatorHandler mediator
                                  )
        {
            this._Pessoas_Repository = Pessoas_Repository;
            this._mapper = mapper;
            this._mediator = mediator;
        }

        public async Task<Pessoas_ViewModel> GetById(int id)
        {
            return _mapper.Map<Pessoas_ViewModel>(await _Pessoas_Repository.GetById(id));
        }

        public async Task<Pessoas_ViewModel> GetDataCustom(Pessoas_Filter filter)
        {
            return _mapper.Map<Pessoas_ViewModel>(await _Pessoas_Repository.GetDataCustom(filter));
        }

        public async Task<IEnumerable<Pessoas_ViewModel>> GetDataListCustom(Pessoas_Filter filter)
        {
            return _mapper.Map<IEnumerable<Pessoas_ViewModel>>(await _Pessoas_Repository.GetDataListCustom(filter));
        }

        public async Task<Pessoas_RegisterCommand> Register(Pessoas_ViewModel viewModel)
        {
            var registerCommand = _mapper.Map<Pessoas_RegisterCommand>(viewModel);
            var result = await _mediator.SendCommand(registerCommand);
            registerCommand.ValidationResult = result;
            return registerCommand;
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var removeCommand = new Pessoas_RemoveCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<Pessoas_UpdateCommand> Update(Pessoas_ViewModel viewModel)
        {
            var updateCommand = _mapper.Map<Pessoas_UpdateCommand>(viewModel);
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
