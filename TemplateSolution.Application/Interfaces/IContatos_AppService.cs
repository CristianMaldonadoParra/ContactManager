using FluentValidation.Results;
using TemplateSolution.Application.ViewModels;
using TemplateSolution.Domain.Commands.Contatos;
using TemplateSolution.Domain.Commands.Pessoas;
using TemplateSolution.Domain.Filters;

namespace TemplateSolution.Application.Interfaces
{
    public interface IContatos_AppService: IDisposable
    {
        Task<Contatos_ViewModel> GetById(int id);
        Task<Contatos_ViewModel> GetDataCustom(Contatos_Filter filter);
        Task<IEnumerable<Contatos_ViewModel>> GetDataListCustom(Contatos_Filter filter);
        Task<Contatos_RegisterCommand> Register(Contatos_ViewModel viewModel);
        Task<Contatos_UpdateCommand> Update(Contatos_ViewModel viewModel);
        Task<ValidationResult> Remove(int id);
    }
}
