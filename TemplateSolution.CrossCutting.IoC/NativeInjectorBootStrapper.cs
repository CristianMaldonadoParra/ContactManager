using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateSolution.Application.Interfaces;
using TemplateSolution.Application.Services;
using TemplateSolution.Domain.Commands.Contatos;
using TemplateSolution.Domain.Commands.Pessoas;
using TemplateSolution.Domain.Core.Core.Mediator;
using TemplateSolution.Domain.Core.Events;
using TemplateSolution.Domain.Interfaces;
using TemplateSolution.Infra.CrossCutting.Bus;
using TemplateSolution.Infra.Data.Context;
using TemplateSolution.Infra.Data.Repository;

namespace TemplateSolution.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application

            services.AddScoped<IPessoas_AppService, Pessoas_AppService>();
            services.AddScoped<IContatos_AppService, Contatos_AppService>();

            // Domain - Events
            //services.AddScoped<INotificationHandler<OBJETO>, OBJETO>();


            // Domain - Commands
            services.AddScoped<IRequestHandler<Pessoas_RegisterCommand, ValidationResult>, Pessoas_CommandHandler>();
            services.AddScoped<IRequestHandler<Pessoas_UpdateCommand, ValidationResult>, Pessoas_CommandHandler>();
            services.AddScoped<IRequestHandler<Pessoas_RemoveCommand, ValidationResult>, Pessoas_CommandHandler>();

            services.AddScoped<IRequestHandler<Contatos_RegisterCommand, ValidationResult>, Contatos_CommandHandler>();
            services.AddScoped<IRequestHandler<Contatos_UpdateCommand, ValidationResult>,   Contatos_CommandHandler>();
            services.AddScoped<IRequestHandler<Contatos_RemoveCommand, ValidationResult>,   Contatos_CommandHandler>();


            // Infra - Data
            services.AddScoped<ContextDB>();
           
            services.AddScoped<IPessoas_Repository, PessoasRepository>();
            services.AddScoped<IContatos_Repository, ContatosRepository>();
            
            // Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSqlContext>();


            //Context Accessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
