using iTalentBlogProject.Web.Models;

namespace iTalentBlogProject.Web.Services
{
    public class PostApiService
    {
        private readonly HttpClient _httpClient;

        public PostApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PostViewModel>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomeResponseViewModel<List<PostViewModel>>>("Posts");
            return response.Data;
        }

        public async Task<PostViewModel> SaveAsync(CreatePostViewModel newProduct)
        {
            var createPost = new CreatePostDto
            {
                Article = newProduct.Article,
                CategoryId = newProduct.CategoryId,
                PhotoUrl = newProduct.Photo.FileName,
                Title = newProduct.Title
            };
            var response = await _httpClient.PostAsJsonAsync("Posts", createPost);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseBody = await response.Content.ReadFromJsonAsync<CustomeResponseViewModel<PostViewModel>>();
            return responseBody.Data;
        }

        public async Task<UpdatePostViewModel> GetAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomeResponseViewModel<UpdatePostViewModel>>($"Posts/{id}");
            return response.Data;
        }

        public async Task<bool> UpdateAsync(UpdatePostViewModel updateProduct)
        {
            var updatePostDto = new UpdatePostDto
            {
                Id = updateProduct.Id,
                Article = updateProduct.Article,
                CategoryId = updateProduct.CategoryId,
                PhotoUrl = updateProduct.Photo.FileName,
                Title = updateProduct.Title
            };
            var response = await _httpClient.PutAsJsonAsync("Posts", updatePostDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Posts/{id}");
            return response.IsSuccessStatusCode;
        }


        public async Task<GetPostWithPagedViewModel> GetPostWithPagedAsync(int page)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomeResponseViewModel<GetPostWithPagedViewModel>>($"Posts/GetPostsWithPaged/page/{page}");
            return response.Data;
        }

        public async Task<List<PostViewModel>> GetPostsByCategoryIdAsync(int categoryId)
        {
            var response =
                await _httpClient.GetFromJsonAsync<CustomeResponseViewModel<List<PostViewModel>>>(
                    $"Posts/GetPostsWithPaged/{categoryId}");
            return response.Data;
        }

        public async Task<GetPostWithPagedViewModel> GetPostsWithPagedByCategoryId(int page, int categoryId)
        {
            var response =
                await _httpClient.GetFromJsonAsync<CustomeResponseViewModel<GetPostWithPagedViewModel>>(
                    $"Posts/GetPostsByCategoryId/{categoryId}/page/{page}");
            return response.Data;
        }

        public async Task<PostWithCommentsViewModel> GetPostWithCommentsById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomeResponseViewModel<PostWithCommentsViewModel>>($"Posts/GetPostWithComments/{id}");
            return response.Data;
        }
    }
}
