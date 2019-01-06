using demo.Application.Behaviors;
using MediatR;
using System.Runtime.Serialization;

namespace demo.Application.Commands
{
    [DataContract]
    public class CreateBlogCommand : IRequest<Response>
    {
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string Title { get; set; }

        public CreateBlogCommand() { }
        public CreateBlogCommand(string url, string title)
        {
            Url = url;
            Title = title;
        }
    }
}
