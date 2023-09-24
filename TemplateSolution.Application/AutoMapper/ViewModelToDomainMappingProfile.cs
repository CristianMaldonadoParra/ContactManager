using AutoMapper;
using TemplateSolution.Application.ViewModels;
using TemplateSolution.Domain.Commands.Contatos;
using TemplateSolution.Domain.Commands.Pessoas;

namespace TemplateSolution.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap(typeof(Pessoas_ViewModel), typeof(Pessoas_RegisterCommand)).ReverseMap();
            CreateMap(typeof(Contatos_ViewModel), typeof(Contatos_RegisterCommand)).ReverseMap();

            CreateMap(typeof(Pessoas_ViewModel), typeof(Pessoas_UpdateCommand)).ReverseMap();
            CreateMap(typeof(Contatos_ViewModel), typeof(Contatos_UpdateCommand)).ReverseMap();
        }
    }
}
