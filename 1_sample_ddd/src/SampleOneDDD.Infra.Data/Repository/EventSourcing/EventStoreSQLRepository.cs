using System;
using System.Linq;
using System.Collections.Generic;
using SampleOneDDD.Domain.Core.Events;
using SampleOneDDD.Infra.Data.Context;

namespace SampleOneDDD.Infra.Data.Repository.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly SampleOneDDDContext _context;

        public EventStoreSQLRepository(SampleOneDDDContext context)
        {
            _context = context;
        }

        public IList<StoredEvent> All(int aggregateId)
        {
            return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}