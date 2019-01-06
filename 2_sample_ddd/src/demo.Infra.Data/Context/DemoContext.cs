using demo.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace demo.Infra.Data.Context
{
    public class DemoContext : IdentityDbContext<User>
    {       
        public DbSet<Blog> Blogs { get; set; }        

        public DemoContext(DbContextOptions<DemoContext> options)
           : base(options){}       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
