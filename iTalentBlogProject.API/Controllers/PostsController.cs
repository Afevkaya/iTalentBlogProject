using AutoMapper;
using iTalentBlogProject.Core.DTOs;
using iTalentBlogProject.Core.Entities;
using iTalentBlogProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iTalentBlogProject.API.Controllers
{
    public class PostsController : CustomeBaseController
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllAsync();
            var listPostDto = _mapper.Map<List<PostDto>>(posts);
            return CreateActionResult<List<PostDto>>(CustomeResponseDto<List<PostDto>>.Success(listPostDto, 200));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            var postDto = _mapper.Map<PostDto>(post);
            return CreateActionResult<PostDto>(CustomeResponseDto<PostDto>.Success(postDto, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreatePostDto createPostDto)
        {
            var post = _mapper.Map<Post>(createPostDto);
            await _postService.AddAsync(post);
            return CreateActionResult<PostDto>(CustomeResponseDto<PostDto>.Success(_mapper.Map<PostDto>(post), 201));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePostDto updatePosDto)
        {
            var post = await _postService.GetByIdAsync(updatePosDto.Id);
            post = _mapper.Map<Post>(updatePosDto);
            await _postService.UpdateAsync(post);
            return CreateActionResult<NoContentDto>(CustomeResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.RemoveAsync(await _postService.GetByIdAsync(id));
            return CreateActionResult<NoContentDto>(CustomeResponseDto<NoContentDto>.Success(204));
        }
    }
}
