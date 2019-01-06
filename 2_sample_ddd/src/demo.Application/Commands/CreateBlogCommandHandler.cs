using demo.Application.Behaviors;
using demo.Domain.Interfaces;
using demo.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace demo.Application.Commands
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Response>
    {
        private readonly IBlogRepository _blogRepository;

        public CreateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Response> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog(request.Url, "c");

            await _blogRepository.AddAsync(blog);

            return new Response("Book criado com sucesso");
        }
    }
}
