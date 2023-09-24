using FluentValidation.Results;
using TemplateSolution.Application.ViewModels;
using TemplateSolution.Domain.Commands.Pessoas;
using TemplateSolution.Domain.Filters;

namespace TemplateSolution.Application.Interfaces
{
    public interface IPessoas_AppService: IDisposable
    {
        Task<Pessoas_ViewModel> GetById(int id);
        Task<Pessoas_ViewModel> GetDataCustom(Pessoas_Filter filter);
        Task<IEnumerable<Pessoas_ViewModel>> GetDataListCustom(Pessoas_Filter filter);
        Task<Pessoas_RegisterCommand> Register(Pessoas_ViewModel viewModel);
        Task<Pessoas_UpdateCommand> Update(Pessoas_ViewModel viewModel);
        Task<ValidationResult> Remove(int id);
    }
}
