using AutoMapper;
using iTalentBlogProject.Core.DTOs;
using iTalentBlogProject.Core.Entities;
using iTalentBlogProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iTalentBlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
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
            return Ok(CustomResponseDto<List<PostDto>>.Success(listPostDto, 200));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            return new ObjectResult(CustomResponseDto<PostDto>.Success(_mapper.Map<PostDto>(post),200)) {StatusCode = 200};
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreatePostDto createPostDto)
        {
            var post = _mapper.Map<Post>(createPostDto);
            await _postService.AddAsync(post);
            return new ObjectResult(CustomResponseDto<PostDto>.Success(_mapper.Map<PostDto>(post), 201))
                {StatusCode = 201};
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePostDto updatePosDto)
        {
            var post = await _postService.GetByIdAsync(updatePosDto.Id);
            post = _mapper.Map<Post>(updatePosDto);
            await _postService.UpdateAsync(post);
            return new ObjectResult(CustomResponseDto<NoContentDto>.Success(204)) {StatusCode = 204};
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _postService.RemoveAsync(await _postService.GetByIdAsync(id));
            return new ObjectResult(CustomResponseDto<NoContentDto>.Success(204)) {StatusCode = 204};
        }
    }
}
