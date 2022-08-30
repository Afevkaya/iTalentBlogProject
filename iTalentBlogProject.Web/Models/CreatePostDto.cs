namespace iTalentBlogProject.Web.Models
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Article { get; set; }
        public string PhotoUrl { get; set; }

        public int CategoryId { get; set; }
    }
}
