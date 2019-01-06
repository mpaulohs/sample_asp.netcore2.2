using System.Threading;
using System.Threading.Tasks;
using SampleOneDDD.Domain.Commands;
using SampleOneDDD.Domain.Core.Bus;
using SampleOneDDD.Domain.Core.Notifications;
using SampleOneDDD.Domain.Events;
using SampleOneDDD.Domain.Interfaces;
using SampleOneDDD.Domain.Models;
using MediatR;

namespace SampleOneDDD.Domain.CommandHandlers
{
    public class BlogCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewBlogCommand>
       // IRequestHandler<UpdateBlogCommand>,
       // IRequestHandler<RemoveBlogCommand>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMediatorHandler Bus;

        public BlogCommandHandler(IBlogRepository blogRepository, 
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _blogRepository = blogRepository;
            Bus = bus;
        }

        public  Task<Unit> Handle(RegisterNewBlogCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return  Unit.Task;
            }

            var blog = new Blog(message.Url);

            //if (_customerRepository.GetByEmail(customer.Email) != null)
            //{
            //    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
            //    return Unit.Task;
            //}
            
             _blogRepository.Add2(blog);

            if (Commit())
            {
                 Bus.RaiseEvent(new BlogRegisteredEvent(blog.BlogId, blog.Url));
            }
            return  Unit.Task;
            
        }

        //public Task Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        //{
        //    if (!message.IsValid())
        //    {
        //        NotifyValidationErrors(message);
        //        return Task.CompletedTask;
        //    }

        //    var customer = new Customer(message.Id, message.Name, message.Email, message.BirthDate);
        //    var existingCustomer = _customerRepository.GetByEmail(customer.Email);

        //    if (existingCustomer != null && existingCustomer.Id != customer.Id)
        //    {
        //        if (!existingCustomer.Equals(customer))
        //        {
        //            Bus.RaiseEvent(new DomainNotification(message.MessageType,"The customer e-mail has already been taken."));
        //            return Task.CompletedTask;
        //        }
        //    }

        //    _customerRepository.Update(customer);

        //    if (Commit())
        //    {
        //        Bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
        //    }

        //    return Task.CompletedTask;
        //}

        //public Task Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        //{
        //    if (!message.IsValid())
        //    {
        //        NotifyValidationErrors(message);
        //        return Task.CompletedTask;
        //    }

        //    _customerRepository.Remove(message.Id);

        //    if (Commit())
        //    {
        //        Bus.RaiseEvent(new CustomerRemovedEvent(message.Id));
        //    }

        //    return Task.CompletedTask;
        //}

        public void Dispose()
        {
            _blogRepository.Dispose();
        }
    }
}