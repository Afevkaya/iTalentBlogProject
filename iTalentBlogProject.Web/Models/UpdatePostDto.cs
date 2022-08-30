namespace iTalentBlogProject.Web.Models
{
    public class UpdatePostDto
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string Article { get; set; }
        public string PhotoUrl { get; set; }

        public int CategoryId { get; set; }
    }
}
