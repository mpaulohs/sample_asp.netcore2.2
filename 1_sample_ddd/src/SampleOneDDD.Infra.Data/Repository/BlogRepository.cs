using System.Linq;
using SampleOneDDD.Domain.Interfaces;
using SampleOneDDD.Domain.Models;
using SampleOneDDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace SampleOneDDD.Infra.Data.Repository
{
    public class BlogRepository : EfRepository<Blog>, IBlogRepository
    {
        public BlogRepository(SampleOneDDDContext context)
            : base(context){}

    }
}
