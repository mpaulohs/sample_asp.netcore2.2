using SampleOneDDD.Domain.CommandHandlers;
using SampleOneDDD.Domain.Commands;
using SampleOneDDD.Domain.Core.Bus;
using SampleOneDDD.Domain.Core.Events;
using SampleOneDDD.Domain.Core.Notifications;
using SampleOneDDD.Domain.EventHandlers;
using SampleOneDDD.Domain.Events;
using SampleOneDDD.Domain.Interfaces;
using SampleOneDDD.Domain.Models;
using SampleOneDDD.Infra.CrossCutting.Bus;
using SampleOneDDD.Infra.Data.Context;
using SampleOneDDD.Infra.Data.EventSourcing;
using SampleOneDDD.Infra.Data.Repository;
using SampleOneDDD.Infra.Data.Repository.EventSourcing;
using SampleOneDDD.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SampleOneDDD.Application.Interfaces;
using SampleOneDDD.Application.Services;

namespace SampleOneDDD.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
         //   services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IBlogAppService, BlogAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<BlogRegisteredEvent>, BlogEventHandler>();
           // services.AddScoped<INotificationHandler<BlogUpdatedEvent>, BlogEventHandler>();
          //  services.AddScoped<INotificationHandler<BlogRemovedEvent>, BlogEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewBlogCommand>, BlogCommandHandler>();
           // services.AddScoped<IRequestHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
           // services.AddScoped<IRequestHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SampleOneDDDContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            ///services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
         //   services.AddTransient<IEmailSender, AuthEmailMessageSender>();
          //  services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}