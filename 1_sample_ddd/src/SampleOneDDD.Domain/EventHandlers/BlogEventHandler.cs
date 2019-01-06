using System.Threading;
using System.Threading.Tasks;
using SampleOneDDD.Domain.Events;
using MediatR;

namespace SampleOneDDD.Domain.EventHandlers
{
    public class BlogEventHandler :
        INotificationHandler<BlogRegisteredEvent>
        
    {
        //public Task Handle(BlogUpdatedEvent message, CancellationToken cancellationToken)
        //{
        //    // Send some notification e-mail

        //    return Task.CompletedTask;
        //}

        public Task Handle(BlogRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        //public Task Handle(BlogRemovedEvent message, CancellationToken cancellationToken)
        //{
        //    // Send some see you soon e-mail

        //    return Task.CompletedTask;
        //}
    }
}