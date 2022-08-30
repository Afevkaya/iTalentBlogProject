using iTalentBlogProject.Web.Models;

namespace iTalentBlogProject.Web.Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomeResponseViewModel<List<CategoryViewModel>>>("Categories");
            return response.Data;
        }
    }
}
