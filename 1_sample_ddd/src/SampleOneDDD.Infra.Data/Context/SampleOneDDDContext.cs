using SampleOneDDD.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleOneDDD.Domain.Core.Events;

namespace SampleOneDDD.Infra.Data.Context
{
    public class SampleOneDDDContext : IdentityDbContext<User>
    {

        public DbSet<StoredEvent> StoredEvent { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public SampleOneDDDContext(DbContextOptions<SampleOneDDDContext> options)
           : base(options){}
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StoredEvent>()
            .Property(c => c.Timestamp)
            .HasColumnName("CreationDate");

            modelBuilder.Entity<StoredEvent>()
             .Property(c => c.MessageType)
             .HasColumnName("Action")
             .HasColumnType("varchar(100)");


            modelBuilder.Entity<Blog>()
             .HasOne(p => p.BlogImage)
             .WithOne(i => i.Blog)
             .HasForeignKey<BlogImage>(b => b.BlogId);

            modelBuilder.Entity<PostTag>()
            .HasKey(t => new { t.PostId, t.TagId });

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId);

            
        }

    }
}
