using AutoMapper;
using iTalentBlogProject.Core.DTOs;
using iTalentBlogProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iTalentBlogProject.API.Controllers
{
    public class CategoriesController : CustomeBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return CreateActionResult<List<CategoryDto>>(
                CustomeResponseDto<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200));
        }
    }
}
