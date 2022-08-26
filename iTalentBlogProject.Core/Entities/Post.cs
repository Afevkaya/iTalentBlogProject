namespace iTalentBlogProject.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}
