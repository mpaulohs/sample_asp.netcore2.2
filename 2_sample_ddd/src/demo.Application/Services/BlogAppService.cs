using demo.Application.Interfaces;
using demo.Application.ViewModels;
using demo.Domain.Core.Bus;
using demo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace demo.Application.Services
{
    public class BlogAppService : IBlogAppService
    {

        private readonly IBlogRepository _blogRepository;       
        private readonly IMediatorHandler Bus;

        public BlogAppService(
                                  IBlogRepository customerRepository,
                                  IMediatorHandler bus
                                  )
        {

            _blogRepository = customerRepository;
            Bus = bus;            
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<BlogViewModel>> GetAllAsync()
        {
            var list = await _blogRepository.ListAllAsync();
            var resul = new List<BlogViewModel>();
            foreach (var item in list)
            {
                var b = new BlogViewModel
                {
                    Id = item.Id,
                    Url = item.Url
                };
                resul.Add(b);
            }
            return resul;
        }

        public BlogViewModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Register(BlogViewModel blogViewModel)
        {
          //  var registerCommand = new RegisterNewBlogCommand(blogViewModel.Url);
           // Bus.SendCommand(registerCommand);
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(BlogViewModel blogViewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
