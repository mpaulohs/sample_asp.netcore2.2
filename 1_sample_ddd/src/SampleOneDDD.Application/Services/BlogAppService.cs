using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleOneDDD.Application.Interfaces;
using SampleOneDDD.Application.ViewModels;
using SampleOneDDD.Domain.Commands;
using SampleOneDDD.Domain.Core.Bus;
using SampleOneDDD.Domain.Interfaces;
using SampleOneDDD.Infra.Data.Repository.EventSourcing;

namespace SampleOneDDD.Application.Services
{
    public class BlogAppService : IBlogAppService
    {
        
        private readonly IBlogRepository _blogRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public BlogAppService(
                                  IBlogRepository customerRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            
            _blogRepository = customerRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
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
                    Id = item.BlogId,
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
            var registerCommand = new RegisterNewBlogCommand(blogViewModel.Url);
            Bus.SendCommand(registerCommand);
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
