using System.Linq;
using demo.Domain.Interfaces;
using demo.Domain.Models;
using demo.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace demo.Infra.Data.Repository
{
    public class BlogRepository : EfRepository<Blog>, IBlogRepository
    {
        public BlogRepository(DemoContext context)
            : base(context){}

    }
}
