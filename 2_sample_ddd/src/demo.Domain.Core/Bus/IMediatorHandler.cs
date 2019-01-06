using System.Threading.Tasks;
using demo.Domain.Core.Commands;
using demo.Domain.Core.Events;


namespace demo.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
