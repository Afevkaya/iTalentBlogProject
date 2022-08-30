using iTalentBlogProject.Web.Models;
using iTalentBlogProject.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;

namespace iTalentBlogProject.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class PostsController : Controller
    {
        private readonly PostApiService _postApiService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IFileProvider _fileProvider;
        public PostsController(PostApiService postApiService, CategoryApiService categoryApiService, IFileProvider fileProvider)
        {
            _postApiService = postApiService;
            _categoryApiService = categoryApiService;
            _fileProvider = fileProvider;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _postApiService.GetAllAsync());
        }

        [Route("AdminPanel/Posts/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postApiService.RemoveAsync(id);
            return RedirectToAction("Index", "Posts");
        }

        [Route("AdminPanel/Posts/Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var categories = await _categoryApiService.GetAllAsync();
            ViewBag.selectList = new SelectList(categories, dataValueField: "Id", dataTextField: "Name");

            var post = await _postApiService.GetAsync(id);
            return View(post);
        }

        [HttpPost]
        [Route("AdminPanel/Posts/Update/{id}")]
        public async Task<IActionResult> Update(UpdatePostViewModel updatePostViewModel)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryApiService.GetAllAsync();
                ViewBag.selectList = new SelectList(categories, "Id", "Name");
                return View(updatePostViewModel);
            }

            if (updatePostViewModel.Photo != null && updatePostViewModel.Photo.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var pictureDirectory = root.First(x => x.Name == "images");
                var path = Path.Combine(pictureDirectory.PhysicalPath, updatePostViewModel.Photo.FileName);

                using var stream = new FileStream(path, FileMode.Create);
                await updatePostViewModel.Photo.CopyToAsync(stream);
            }

            await _postApiService.UpdateAsync(updatePostViewModel);
            return RedirectToAction("Index", "Posts");
        }

        [HttpGet]
        [Route("AdminPanel/Posts/Create")]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryApiService.GetAllAsync();
            ViewBag.selectList = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Route("AdminPanel/Posts/Create")]
        public async Task<IActionResult> Create(CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryApiService.GetAllAsync();
                ViewBag.selectList = new SelectList(categories, "Id", "Name");
                return View(model);
            }

            if (model.Photo != null && model.Photo.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var pictureDirectory = root.First(x => x.Name == "images");
                var path = Path.Combine(pictureDirectory.PhysicalPath, model.Photo.FileName);

                using var stream = new FileStream(path, FileMode.Create);
                await model.Photo.CopyToAsync(stream);
            }

            await _postApiService.SaveAsync(model);
            return RedirectToAction("Index", "Posts");
        }

    }
}
