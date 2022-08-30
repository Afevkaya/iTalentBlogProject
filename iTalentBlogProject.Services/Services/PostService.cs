using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTalentBlogProject.Core.DTOs;
using iTalentBlogProject.Core.Entities;
using iTalentBlogProject.Core.Repositories;
using iTalentBlogProject.Core.Services;
using iTalentBlogProject.Core.UnitOfWorks;

namespace iTalentBlogProject.Services.Services
{
    public class PostService : GenericService<Post>, IPostService    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostService(IGenericRepository<Post> repository, IUnitOfWork unitOfWork, IMapper mapper, IPostRepository postRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public CustomeResponseDto<GetPostWithPagedDto> GetPostWithPaged(int page, int pageSize)
        {
            var postWithPaged = _postRepository.GetProductWithPaged(page, pageSize);

            return CustomeResponseDto<GetPostWithPagedDto>.Success(_mapper.Map<GetPostWithPagedDto>(postWithPaged),
                200);
        }

        public async Task<CustomeResponseDto<List<PostDto>>> GetPostsByCategoryIdAsync(int categoryId)
        {
            var postList = await _postRepository.GetPostsByCategoryIdAsync(categoryId);
            return CustomeResponseDto<List<PostDto>>.Success(_mapper.Map<List<PostDto>>(postList), 200);
        }

        public CustomeResponseDto<GetPostWithPagedDto> GetPostsWithPagedByCategoryId(int page, int pageSize, int id)
        {
            var postWithPaged = _postRepository.GetProductWithPagedByCategoryId(page, pageSize, id);
            return CustomeResponseDto<GetPostWithPagedDto>.Success(_mapper.Map<GetPostWithPagedDto>(postWithPaged),
                200);
        }

        public async Task<CustomeResponseDto<PostWithCommentsDto>> GetPostWithCommentsById(int id)
        {
            var postWithComments = await _postRepository.GetPostWithCommentsById(id);
            return CustomeResponseDto<PostWithCommentsDto>.Success(_mapper.Map<PostWithCommentsDto>(postWithComments),
                200);
        }
    }
}
