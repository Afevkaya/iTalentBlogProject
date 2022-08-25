using iTalentBlogProject.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace iTalentBlogProject.Repository.Context
{
    public class iTalentBlogContext : DbContext
    {
        public iTalentBlogContext(DbContextOptions<iTalentBlogContext> options) : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
