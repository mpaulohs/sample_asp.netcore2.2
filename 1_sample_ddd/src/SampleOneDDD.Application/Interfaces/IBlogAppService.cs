using SampleOneDDD.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleOneDDD.Application.Interfaces
{
    public interface IBlogAppService : IDisposable
    {
        void Register(BlogViewModel customerViewModel);
        Task<IEnumerable<BlogViewModel>> GetAllAsync();
        BlogViewModel GetById(int id);
        void Update(BlogViewModel blogViewModel);
        void Remove(int id);
        //IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
