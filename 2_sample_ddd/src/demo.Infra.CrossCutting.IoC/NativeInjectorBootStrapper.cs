using demo.Domain.Core.Bus;
using demo.Domain.Interfaces;
using demo.Infra.CrossCutting.Bus;
using demo.Infra.Data.Context;
using demo.Infra.Data.Repository;
using demo.Infra.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace demo.Infra.CrossCutting.IoC
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
            // services.AddScoped<IBlogAppService, BlogAppService>();

            // Domain - Events
           // services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
           // services.AddScoped<INotificationHandler<BlogRegisteredEvent>, BlogEventHandler>();
           // services.AddScoped<INotificationHandler<BlogUpdatedEvent>, BlogEventHandler>();
          //  services.AddScoped<INotificationHandler<BlogRemovedEvent>, BlogEventHandler>();

            // Domain - Commands
          //  services.AddScoped<IRequestHandler<RegisterNewBlogCommand>, BlogCommandHandler>();
           // services.AddScoped<IRequestHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
           // services.AddScoped<IRequestHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();            
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<DemoContext>();

            // Infra - Data EventSourcing
            //  services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            //  services.AddScoped<IEventStore, SqlEventStore>();
            ///services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            //   services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //  services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            //  services.AddScoped<IUser, AspNetUser>();
        }
    }
}