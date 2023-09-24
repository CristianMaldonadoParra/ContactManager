using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateSolution.Application.ViewModels;
using TemplateSolution.Domain.Models;

namespace TemplateSolution.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Pessoas, Pessoas_ViewModel>().ReverseMap();
            CreateMap<Contatos, Contatos_ViewModel>().ReverseMap();
        }
    }
}
