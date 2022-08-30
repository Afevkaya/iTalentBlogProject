using iTalentBlogProject.Core.Entities;
using iTalentBlogProject.Core.Repositories;
using iTalentBlogProject.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace iTalentBlogProject.Repository.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(iTalentBlogContext context) : base(context)
        {
        }

        public (List<Post>, int) GetProductWithPaged(int page , int pageSize)
        {
            IQueryable<Post> query;
            query = _context.Posts.Include(x=>x.Category).OrderByDescending(y => y.CreatedDate);
            int totalCount = query.Count();
            var postList = query.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            return (postList, totalCount);
        }

        public async Task<List<Post>> GetPostsByCategoryIdAsync(int id)
        {
            return await _context.Posts.Include(x => x.Category).Where(x => x.CategoryId == id).ToListAsync();
        }

        public (List<Post>, int) GetProductWithPagedByCategoryId(int page, int pageSize, int id)
        {
            IQueryable<Post> query;
            query = _context.Posts.Include(x => x.Category).Where(x => x.CategoryId == id)
                .OrderByDescending(y => y.CreatedDate);
            int totalCount = query.Count();
            var postList = query.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            return (postList,totalCount);
        }

        public async Task<Post> GetPostWithCommentsById(int id)
        {
            return await _context.Posts.Include(x => x.Comments).Include(x=>x.Category).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
