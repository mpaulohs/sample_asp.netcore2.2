using System;
using System.Collections.Generic;
using SampleOneDDD.Domain.Core.Events;

namespace SampleOneDDD.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(int aggregateId);
    }
}