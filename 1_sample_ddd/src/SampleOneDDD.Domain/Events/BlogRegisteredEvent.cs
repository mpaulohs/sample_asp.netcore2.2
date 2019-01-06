using System;
using SampleOneDDD.Domain.Core.Events;

namespace SampleOneDDD.Domain.Events
{
    public class BlogRegisteredEvent : Event
    {
        public BlogRegisteredEvent(int id, string url)
        {
            Id = id;
            Url = url;
            AggregateId = id;
        }
        public int Id { get; set; }

        public string Url { get; private set; }       
    }
}