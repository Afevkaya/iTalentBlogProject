using AutoMapper;
using iTalentBlogProject.Core.DTOs;
using iTalentBlogProject.Core.Entities;
using iTalentBlogProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iTalentBlogProject.API.Controllers
{
    public class CommentsController : CustomeBaseController
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreateCommentDto createCommentDto)
        {
            var comment = _mapper.Map<Comment>(createCommentDto);
            await _commentService.AddAsync(comment);
            var commentDto = _mapper.Map<CommentDto>(comment);
            return CreateActionResult<CommentDto>(CustomeResponseDto<CommentDto>.Success(commentDto, 201));
        }
    }
}
