using iTalentBlogProject.Core.Entities;
using iTalentBlogProject.Core.Repositories;
using iTalentBlogProject.Repository.Context;

namespace iTalentBlogProject.Repository.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(iTalentBlogContext context) : base(context)
        {
        }
    }
}
