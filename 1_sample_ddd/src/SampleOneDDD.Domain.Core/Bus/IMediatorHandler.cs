using System.Threading.Tasks;
using SampleOneDDD.Domain.Core.Commands;
using SampleOneDDD.Domain.Core.Events;


namespace SampleOneDDD.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
