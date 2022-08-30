using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using iTalentBlogProject.Core.DTOs;
using iTalentBlogProject.Core.Entities;

namespace iTalentBlogProject.Core.Services
{
    public interface IPostService : IGenericService<Post>
    {
        CustomeResponseDto<GetPostWithPagedDto> GetPostWithPaged(int page, int pageSize);
        Task<CustomeResponseDto<List<PostDto>>> GetPostsByCategoryIdAsync(int categoryId);
        CustomeResponseDto<GetPostWithPagedDto> GetPostsWithPagedByCategoryId(int page, int pageSize, int id);
        Task<CustomeResponseDto<PostWithCommentsDto>> GetPostWithCommentsById(int id);
    }
}
