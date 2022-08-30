using iTalentBlogProject.Core.Entities;

namespace iTalentBlogProject.Core.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        (List<Post>, int) GetProductWithPaged(int page, int pageSize);
        Task<List<Post>> GetPostsByCategoryIdAsync(int id);
        (List<Post>, int) GetProductWithPagedByCategoryId(int page, int pageSize, int id);
        Task<Post> GetPostWithCommentsById(int id);
    }
}
