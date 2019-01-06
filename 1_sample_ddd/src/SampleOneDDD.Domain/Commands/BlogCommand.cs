using System;
using SampleOneDDD.Domain.Core.Commands;

namespace SampleOneDDD.Domain.Commands
{
    public abstract class BlogCommand : Command
    {
        public int Id { get; protected set; }

        public string Url { get; protected set; }       
    }
}