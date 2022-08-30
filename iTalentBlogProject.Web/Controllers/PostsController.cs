using iTalentBlogProject.Web.Models;
using iTalentBlogProject.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace iTalentBlogProject.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly PostApiService _postApiService;

        public PostsController(PostApiService postApiService, IFileProvider fileProvider)
        {
            _postApiService = postApiService;
        }

        [Route("{page}")]
        public async Task<ActionResult> Index(int page = 1)
        {
            int pageSize = 4;
            int totalCount = _postApiService.GetPostWithPagedAsync(page).Result.totalCount;
            int totalPage = (int)(Math.Ceiling((decimal)totalCount) / pageSize) + 1;

            ViewBag.page = page;
            ViewBag.totalPage = totalPage;

            return View(await _postApiService.GetPostWithPagedAsync(page));
        }

        public async Task<ActionResult> PostDetails(int id)
        {
            var postWithComments = await _postApiService.GetPostWithCommentsById(id);
            return View(postWithComments);
        }

        /*[Route("[action]/{categoryId}")]
        public async Task<ActionResult> PostByCategoryId(int categoryId)
        {
            return View(await _postApiService.GetPostsByCategoryIdAsync(categoryId));
        }*/

        [Route("{categoryId}/page/{page}")]
        public async Task<ActionResult> PostByCategoryId(int categoryId, int page)
        {

            int pageSize = 4;
            int totalCount = _postApiService.GetPostsWithPagedByCategoryId(page, categoryId).Result.totalCount;
            int totalPage = (int)(Math.Ceiling((decimal)totalCount) / pageSize) + 1;

            ViewBag.categoryId = categoryId;
            ViewBag.page = page;
            ViewBag.totalPage = totalPage;
            return View(await _postApiService.GetPostsWithPagedByCategoryId(page, categoryId));
        }


    }
}
