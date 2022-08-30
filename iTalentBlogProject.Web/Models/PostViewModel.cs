using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBlogProject.Web.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
