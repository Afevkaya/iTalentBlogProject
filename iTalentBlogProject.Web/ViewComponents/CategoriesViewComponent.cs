using iTalentBlogProject.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace iTalentBlogProject.Web.ViewComponents
{
    public class CategoriesViewComponent: ViewComponent
    {
        private readonly CategoryApiService _categoryApiService;

        public CategoriesViewComponent(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryApiService.GetAllAsync();
            return View(categories);
        }
    }
}
