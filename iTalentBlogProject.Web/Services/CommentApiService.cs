using iTalentBlogProject.Web.Models;

namespace iTalentBlogProject.Web.Services
{
    public class CommentApiService
    {
        private readonly HttpClient _httpClient;

        public CommentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CommentViewModel> Save(CreateCommentViewModel newComment)
        {
            var response = await _httpClient.PostAsJsonAsync("Comments", newComment);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseBody = await response.Content.ReadFromJsonAsync<CustomeResponseViewModel<CommentViewModel>>();
            return responseBody.Data;
        }
    }
}
